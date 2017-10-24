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
    class UserStatistics : IUserStatistics
    {
        IUnitOfWork unitOfWork;
        private string errorMessage = "";

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
            //errorMessage = $"There is no statistics for user {userName} and card with Id {cardId}";
            var stats = unitOfWork.Statistics.GetAll()
                .FirstOrDefault(s => s.User.UserName == userName && s.Card.Id == cardId);
            return stats; // ?? throw new ArgumentNullException(errorMessage);
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
                    User = unitOfWork.Users.FindByName(userLogin)
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
