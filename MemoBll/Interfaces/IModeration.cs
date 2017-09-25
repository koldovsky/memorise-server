using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface IModeration
    {
        int GetReportCountForReason(string reason);
        IEnumerable<Report> GetAllReportsOnReason(string reason);
        IEnumerable<Report> GetAllReportsOnDate(DateTime date);
        IEnumerable<Report> GetAllReportsFromDate(DateTime date);
        Report GetReport(int reportId);
        IEnumerable<Statistics> GetDeckStatistics(int deckId);
        Statistics GetStatistics(string deckName, int userId);
        void DeleteStatistics(Statistics statistics);
        IEnumerable<User> GetAllUsersByCourse(int courseId);
        IEnumerable<User> GetAllUsersByDeck(string deckName);
    }
}
