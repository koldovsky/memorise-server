using System;
using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using Microsoft.AspNet.Identity;

namespace MemoBll.Logic
{
    public class UserStatistics : IUserStatistics
    {
        private IUnitOfWork unitOfWork;
        private string errorMessage = string.Empty;

        private const int CORRECT = 1;
        private const int INCORRECT = -1;
        private const int NOANSWER = 0;

        public UserStatistics()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public UserStatistics(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public Statistics GetStatistics(string userName, int cardId)
        {
            var stats = unitOfWork.Statistics.GetAll()
                .FirstOrDefault(s => s.User.UserName == userName && s.Card.Id == cardId);
            return stats;
        }

        public IEnumerable<Statistics> GetUserStatistics(string userLogin)
        {
            var stats = unitOfWork.Statistics.GetAll()
                .Where(stat => stat.User.UserName == userLogin);
            return stats;
        }

        public IEnumerable<Statistics> GetDeckStatistics(string userName, int deckId)
        {
            errorMessage = $"Can not find deck with Id {deckId}";
            var cards = unitOfWork.Decks.Get(deckId)
                ?.Cards
                ?? throw new ArgumentNullException(errorMessage);
            return cards.Select(card => GetStatistics(userName, card.Id));
        }

        public IEnumerable<Statistics> GetCourseStatistics(string userName, int courseId)
        {
            errorMessage = $"Can not find course with Id {courseId}";
            var decks = unitOfWork.Courses.Get(courseId)
                ?.Decks
                ?? throw new ArgumentNullException(errorMessage);

            var cards = decks
                .Select(d => d.Cards).Aggregate((acc, c) => acc.Concat(c).ToList());

            return cards.Select(card => GetStatistics(userName, card.Id));
        }

        public Statistics CreateStatistics(string userLogin, int cardId)
        {
            var statistics = GetStatistics(userLogin, cardId);
            if (statistics == null)
            {
                statistics = new Statistics
                {
                    Card = unitOfWork.Cards.Get(cardId),
                    CardStatus = 0,
                    User = unitOfWork.Users.FindByName(userLogin),
                    NumbersOfSequentialCorrectAnswers = 0
                };
                unitOfWork.Statistics.Create(statistics);
                unitOfWork.Save();
            }

            return statistics;
        }

        public IEnumerable<Statistics> CreateDeckStatistics(string userName, int deckId)
        {
            errorMessage = $"Can not find deck with Id {deckId}";
            var cards = unitOfWork.Decks.Get(deckId)
                ?.Cards
                ?? throw new ArgumentNullException(errorMessage);

            return cards.Select(card => CreateStatistics(userName, card.Id));
        }

        public IEnumerable<Statistics> CreateCourseStatistics(string userName, int courseId)
        {
            errorMessage = $"Can not find course with Id {courseId}";
            var decks = unitOfWork.Courses.Get(courseId)
                ?.Decks
                ?? throw new ArgumentNullException(errorMessage);

            return decks.Select(deck => CreateDeckStatistics(userName, deck.Id))
                .Aggregate((acc, x) => acc.Concat(x));
        }

        public Statistics UpdateStatistics(Statistics statistics)
        {
            if (statistics.CardStatus == 1)
            {
                if (statistics.NumbersOfSequentialCorrectAnswers == 0)
                {
                    statistics.DateOfPassingQuiz = DateTime.Now;
                }
                statistics.NumbersOfSequentialCorrectAnswers++;
            }
            else
            {
                statistics.NumbersOfSequentialCorrectAnswers = 0;
            }

            unitOfWork.Statistics.Update(statistics);
            unitOfWork.Save();

            return statistics;
        }

        public Statistics DeleteStatistics(int statisticsId)
        {
            var statistics = unitOfWork.Statistics.Get(statisticsId);
            unitOfWork.Statistics.Delete(statisticsId);
            unitOfWork.Save();

            return statistics;
        }
    }
}
