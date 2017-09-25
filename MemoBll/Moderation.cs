using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;

namespace MemoBll
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

        public IEnumerable<Statistics> GetDeckStatistics(int deckId)
        {
            return unitOfWork.Statistics
                .GetAll().Where(x => x.Deck.Id == deckId);
        }

        public Statistics GetStatistics(string deckName, int userId)
        {
            return unitOfWork.Statistics
                .GetAll()
                .FirstOrDefault(x => x.Deck.Name == deckName && x.User.Id == userId);
        }

        public void DeleteStatistics(Statistics statistics)
        {
            unitOfWork.Statistics.Delete(statistics);
            unitOfWork.Save();
        }

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
    }
}
