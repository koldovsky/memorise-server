using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
    public class Moderation : IModeration
    {
        private IUnitOfWork unitOfWork;

        public Moderation()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public Moderation(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region ForReports

        public int GetReportCountForReason(string reason)
        {
            return unitOfWork.Reports.GetAll().Count(x => x.Reason == reason);
        }

        public IEnumerable<Report> GetAllReportsOnReason(string reason)
        {
            return unitOfWork.Reports
                .GetAll().Where(x => x.Reason == reason);
        }

        public IEnumerable<Report> GetAllReportsOnDate(DateTime date)
        {
            return unitOfWork.Reports
                .GetAll().Where(x => x.Date == date);
        }

        public IEnumerable<Report> GetAllReportsFromDate(DateTime date)
        {
            return unitOfWork.Reports
                .GetAll().Where(x => x.Date >= date);
        }

        public Report GetReport(int reportId)
        {
            return unitOfWork.Reports.Get(reportId);
        }

        #endregion

        #region ForStatistics

        public IEnumerable<Statistics> GetDeckStatistics(int deckId)
        {
            return unitOfWork.Statistics
                .GetAll().Where(x => x.Card.Deck.Id == deckId);
        }

        public Statistics GetStatistics(string deckName, int userId)
        {
            return unitOfWork.Statistics
                .GetAll()
                .FirstOrDefault(x => x.Card.Deck.Name == deckName
                && x.User.UserProfile.Id == userId);
        }

        public void DeleteStatistics(int statisticsId)
        {
            unitOfWork.Statistics.Delete(statisticsId);
            unitOfWork.Save();
        }

        #endregion

        #region ForUserBy

        public IEnumerable<User> GetAllUsersByCourse(int courseId)
        {
            IEnumerable<SubscribedCourse> subscribedCourses = unitOfWork.SubscribedCourses
                .GetAll().Where(x => x.Course.Id == courseId);
            List<User> users = new List<User>();
            foreach (var subscribedCourse in subscribedCourses)
            {
                users.Add(subscribedCourse.User);
            }

            return users;
        }

        public IEnumerable<User> GetAllUsersByDeck(int deckid)
        {
            IEnumerable<SubscribedDeck> subscribedDecks = unitOfWork.SubscribedDecks
                .GetAll().Where(x => x.Deck.Id == deckid);
            List<User> users = new List<User>();
            foreach (var subscribedDeck in subscribedDecks)
            {
                users.Add(subscribedDeck.User);
            }

            return users;
        }

        #endregion

        #region ForDeck

        public void CreateDeck(Deck deck)
        {
            unitOfWork.Decks.Create(deck);
            unitOfWork.Save();
        }

        public void UpdateDeck(Deck deck)
        {
            unitOfWork.Decks.Update(deck);
            unitOfWork.Save();
        }

        public void RemoveDeck(int deckId)
        {
            Deck deck = unitOfWork.Decks.Get(deckId);
            if (deck.Cards.Count > 0)
            {
                foreach (var card in deck.Cards.ToList())
                {
                    RemoveCard(card.Id);
                }

            }
            unitOfWork.Decks.Delete(deckId);
            unitOfWork.Save();
        }

        public Deck FindDeckByName(string deckName)
        {
            return unitOfWork.Decks.GetAll()
                .Where(c => c.Name.ToLower() == deckName.ToLower())
                .FirstOrDefault();
        }

        public Deck FindDeckByLinking(string deckLinking)
        {
            return unitOfWork.Decks.GetAll()
                .Where(c => c.Linking.ToLower() == deckLinking.ToLower())
                .FirstOrDefault();
        }

        #endregion

        #region ForCard

        public void CreateCard(Card card)
        {
            unitOfWork.Cards.Create(card);
            unitOfWork.Save();
        }

        public void UpdateCard(Card card)
        {
            unitOfWork.Cards.Update(card);
            unitOfWork.Save();
        }

        public void RemoveCard(int cardId)
        {
            Card card = unitOfWork.Cards.Get(cardId);
            if (card.Answers.Count > 0)
            {
                foreach (var answer in card.Answers.ToList())
                {
                    RemoveAnswer(answer.Id);
                }

            }
            unitOfWork.Cards.Delete(cardId);
            unitOfWork.Save();
        }

        public Card FindCardById(int cardId)
        {
            return unitOfWork.Cards.Get(cardId);
        }


        #endregion

        #region CardType

        public IEnumerable<CardType> GetAllCardTypes()
        {
            return unitOfWork.CardTypes.GetAll();
        }

        public CardType FindCardTypeByName(string cardTypeName)
        {
            return unitOfWork.CardTypes.GetAll()
                .Where(c => c.Name.ToLower() == cardTypeName.ToLower())
                .FirstOrDefault();
        }

        #endregion

        #region ForCategory

        public void CreateCategory(Category category)
        {
            unitOfWork.Categories.Create(category);
            unitOfWork.Save();
        }

        public void UpdateCategory(Category category)
        {
            unitOfWork.Categories.Update(category);
            unitOfWork.Save();
        }

        public void RemoveCategory(int categoryId)
        {
            Category category = unitOfWork.Categories.Get(categoryId);
            if (category.Decks.Count > 0)
            {
                foreach (var deck in category.Decks.ToList())
                {
                    RemoveDeck(deck.Id);
                }
            }

            if (category.Courses.Count > 0)
            {
                foreach (var course in category.Courses.ToList())
                {
                    RemoveCourse(course.Id);
                }
            }

            unitOfWork.Categories.Delete(categoryId);
            unitOfWork.Save();
        }

        public Category FindCategoryByName(string categoryName)
        {
            return unitOfWork.Categories
                .GetAll()
                .FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower());
        }

        public Category FindCategoryByLinking(string categoryLinking)
        {
            return unitOfWork.Categories
                .GetAll()
                .FirstOrDefault(c => c.Linking.ToLower() == categoryLinking.ToLower());
        }

        #endregion

        #region ForCourse

        public void CreateCourse(Course course)
        {
            unitOfWork.Courses.Create(course);
            unitOfWork.Save();
        }

        public void UpdateCourse(Course course)
        {
            unitOfWork.Courses.Update(course);
            unitOfWork.Save();
        }

        public void RemoveCourse(int courseId)
        {
            unitOfWork.Courses.Delete(courseId);
            unitOfWork.Save();
        }

        public Course FindCourseByName(string courseName)
        {
            return unitOfWork.Courses.GetAll()
                .Where(c => c.Name.ToLower() == courseName.ToLower())
                .FirstOrDefault();
        }

        public Course FindCourseByLinking(string courseLinking)
        {
            return unitOfWork.Courses.GetAll()
                .Where(c => c.Linking.ToLower() == courseLinking.ToLower())
                .FirstOrDefault();
        }

        #endregion

        #region ForAnswer

        public Answer CreateAnswer(Answer answer)
        {
            unitOfWork.Answers.Create(answer);
            unitOfWork.Save();
            return answer;
        }

        public void UpdateAnswer(Answer answer)
        {
            unitOfWork.Answers.Update(answer);
            unitOfWork.Save();
        }

        public void RemoveAnswer(int answerId)
        {
            unitOfWork.Answers.Delete(answerId);
            unitOfWork.Save();
        }

        ////public Statistics GetStatistics(string deckName, int userId)
        ////{
        ////    throw new NotImplementedException();
        ////}

        #endregion
       
    }
}
