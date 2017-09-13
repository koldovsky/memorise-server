using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class Moderation
    {

        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        public int GetReportCountForReason(string reason)
        {
            return unitOfWork.Reports.GetCollectionByPredicate(x => x.Reason == reason).Count();
        }

        public List<Report> GetAllReportsOnReason(string reason)
        {
            return unitOfWork.Reports.GetCollectionByPredicate(x => x.Reason == reason).ToList();
        }

        public List<Report> GetAllReportsOnDate(DateTime date)
        {
            return unitOfWork.Reports.GetCollectionByPredicate(x => x.Date == date).ToList();
        }

        public List<Report> GetAllReportsFromDate(DateTime date)
        {
            return unitOfWork.Reports.GetCollectionByPredicate(x => x.Date >= date).ToList();
        }

        public Report GetReport(int reportId)
        {
            return unitOfWork.Reports.Get(reportId);
        }

        public int GetDeckStatistics(int deckId)
        {
            List<Statistic> deckStatistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Id == deckId).ToList();

            if (deckStatistics.Count > 0)
            {
                double totalDeckPercent = 0.0;
                double result = 0.0;

                foreach (Statistic statistic in deckStatistics)
                {
                    totalDeckPercent += statistic.SuccessPercent;
                }
                result = Math.Round(totalDeckPercent / deckStatistics.Count);

                return Convert.ToInt32(result);
            }
            return 0;
        }

        public int GetCourseStatistics(int courseId)
        {
            List<DeckCourse> deckCourses = unitOfWork.DeckCourses.GetCollectionByPredicate(x => x.Course.Id == courseId).ToList();

            if (deckCourses.Count > 1)
            {
                double totalCoursePercent = 0.0;
                double result = 0.0;
                foreach (DeckCourse deckCourse in deckCourses)
                {
                    totalCoursePercent += GetDeckStatistics(deckCourse.Deck.Id);
                }
                result = Math.Round(totalCoursePercent / deckCourses.Count);
                return Convert.ToInt32(result);
            }
            return 0;
        }

        public int GetStatistics(int deckId, int userId)
        {
            List<Statistic> statistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Id == deckId && x.User.Id == userId).ToList();
            if (statistics.Count > 1)
            {
                return statistics[0].SuccessPercent;
            }
            return 0;
        }

        public void DeleteStatistics(Statistic statistics)
        {
            unitOfWork.Statistics.Delete(statistics);
            unitOfWork.Save();
        }

        public List<User> GetAllUsersByCourse(int courseId) 
        {
            List<UserCourse> userCourses = unitOfWork.UserCourses.GetCollectionByPredicate(x => x.Course.Id == courseId).ToList();
            List<User> users = new List<User>();
            foreach (UserCourse userCourse in userCourses)
            {
                users.Add(userCourse.User);
            }
            return users;
        }

        //Returns all users which add some deck
        //Maybe will be method that returns users whish evaluate or pass some deck
        public List<User> GetAllUsersByDeck(int deckId)
        {
            List<Statistic> statistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Id == deckId).ToList();
            List<User> users = new List<User>();
            foreach (Statistic item in statistics)
            {
                users.Add(item.User);
            }
            return users;
        }
    }
}
