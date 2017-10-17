using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface ICustomerStatistics
    {
        Statistics GetStatistics(string userId, int cardId);
        IEnumerable<Statistics> GetDeckStatistics(string userId, int deckId);
        IEnumerable<Statistics> GetCourseStatistics(string userId, int courseId);
        void CreateStatistics(Statistics statistics);
        void CreateDeckStatistics(string userLogin, int deckId);
        void CreateCourseStatistics(string userLogin, int courseId);
        void UpdateStatistics(Statistics statistics);
        void DeleteStatistics(int statisticsId);
    }
}
