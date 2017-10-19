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
    class UserStatistics: IUserStatistics
    {
        IUnitOfWork unitOfWork;

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
            return stats ?? new Statistics
            {
                Card = unitOfWork.Cards.Get(cardId),
                CardStatus = 0,
                User = unitOfWork.Users.FindByName(userName)
            };
        }

        public IEnumerable<Statistics> GetDeckStatistics(string userName, int deckId)
        {
            var cards = unitOfWork.Decks.Get(deckId)
                ?.Cards 
                ?? throw new ArgumentNullException();
            return cards.Select(card => GetStatistics(userName, card.Id));
        }

        public IEnumerable<Statistics> GetCourseStatistics(string userName, int courseId)
        {
            var decks = unitOfWork.Courses.Get(courseId)
                ?.Decks
                ?? throw new ArgumentNullException();
            var cards = decks
                .Select(d => d.Cards).Aggregate((acc, c) => acc.Concat(c).ToList());

            return cards.Select(card => GetStatistics(userName, card.Id));
        }

        public void CreateStatistics(Statistics statistics)
        {
            unitOfWork.Statistics.Create(statistics);
            unitOfWork.Save();
        }

        public void CreateDeckStatistics(string userName, int deckId)
        {
            var user = unitOfWork.Users.FindByName(userName);
            var cards = unitOfWork.Decks.Get(deckId)
                ?.Cards
                ?? throw new ArgumentNullException();
            cards.ToList().ForEach(card =>
            {
                var statistics = new Statistics
                {
                    Card = card,
                    CardStatus = 0,
                    User = user
                };
                CreateStatistics(statistics);
            });
        }

        public void CreateCourseStatistics(string userName, int courseId)
        {
            var decks = unitOfWork.Courses.Get(courseId)
                ?.Decks
                ?? throw new ArgumentNullException();
            decks.ToList().ForEach(deck => CreateDeckStatistics(userName, deck.Id));
        }

        public void UpdateStatistics(Statistics statistics)
        {
            unitOfWork.Statistics.Update(statistics);
            unitOfWork.Save();
        }

        public void DeleteStatistics(int statisticsId)
        {
            unitOfWork.Statistics.Delete(statisticsId);
            unitOfWork.Save();
        }
    }
}
