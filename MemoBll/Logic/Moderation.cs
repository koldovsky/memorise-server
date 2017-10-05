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
        IUnitOfWork unitOfWork;

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
                .GetAll().Where(x => x.Deck.Id == deckId);
        }

        public Statistics GetStatistics(string deckName, int userId)
        {
            return unitOfWork.Statistics
                .GetAll()
                .FirstOrDefault(x => x.Deck.Name == deckName
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
            IEnumerable<UserCourse> userCourses = unitOfWork.UserCourses
                .GetAll().Where(x => x.Course.Id == courseId);
            List<User> users = new List<User>();
            foreach (UserCourse userCourse in userCourses)
            {
                users.Add(userCourse.User);
            }

            return users;
        }

        public IEnumerable<User> GetAllUsersByDeck(string deckName)
        {
            IEnumerable<Statistics> statistics = unitOfWork.Statistics
                .GetAll().Where(x => x.Deck.Name == deckName);
            List<User> users = new List<User>();
            foreach (var item in statistics)
            {
                users.Add(item.User);
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
            unitOfWork.Decks.Delete(deckId);
            unitOfWork.Save();
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
            unitOfWork.Cards.Delete(cardId);
            unitOfWork.Save();
        }

        #endregion

        #region ForCategory

        public void AddCategory(Category category)
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
            unitOfWork.Categories.Delete(categoryId);
            unitOfWork.Save();
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

        #endregion

        #region ForAnswer

        public void CreateAnswer(Answer answer)
        {
            unitOfWork.Answers.Create(answer);
            unitOfWork.Save();
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

        //public Statistics GetStatistics(string deckName, int userId)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
