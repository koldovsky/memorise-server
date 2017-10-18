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
    class CustomerStatistics: ICustomerStatistics
    {
        IUnitOfWork unitOfWork;

        public CustomerStatistics()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public CustomerStatistics(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public Statistics GetStatistics(string userLogin, int cardId)
        {
            var stats = unitOfWork.Statistics.GetAll()
                .FirstOrDefault(s => s.User.UserName == userLogin && s.Card.Id == cardId);
            return stats ?? new Statistics
            {
                Card = unitOfWork.Cards.Get(cardId),
                CardStatus = 0,
                User = unitOfWork.Users.FindByName(userLogin)
            };
        }

        public IEnumerable<Statistics> GetDeckStatistics(string userLogin, int deckId)
        {
            var cards = unitOfWork.Decks.Get(deckId)?.Cards;
            return cards?.Select(card => GetStatistics(userLogin, card.Id))
                ?? throw new ArgumentNullException();
        }

        public IEnumerable<Statistics> GetCourseStatistics(string userLogin, int courseId)
        {
            var decks = unitOfWork.Courses.Get(courseId)
                ?.Decks
                ?? throw new ArgumentNullException();
            var cards = decks
                .Select(d => d.Cards).Aggregate((acc, c) => acc.Concat(c).ToList());

            return cards.Select(card => GetStatistics(userLogin, card.Id));
        }

        public void CreateStatistics(Statistics statistics)
        {
            unitOfWork.Statistics.Create(statistics);
            unitOfWork.Save();
        }

        public void CreateDeckStatistics(string userLogin, int deckId)
        {
            var user = unitOfWork.Users.FindByName(userLogin);
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

        public void CreateCourseStatistics(string userLogin, int courseId)
        {
            var decks = unitOfWork.Courses.Get(courseId)
                ?.Decks
                ?? throw new ArgumentNullException();
            decks.ToList().ForEach(deck => CreateDeckStatistics(userLogin, deck.Id));
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
