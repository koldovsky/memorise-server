using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface IUserStatistics
    {
        Statistics GetStatistics(string userId, int cardId);
        IEnumerable<Statistics> GetDeckStatistics(string userId, int deckId);
        IEnumerable<Statistics> GetCourseStatistics(string userId, int courseId);
        Statistics CreateStatistics(Statistics statistics);
        IEnumerable<Statistics> CreateDeckStatistics(string userLogin, int deckId);
        IEnumerable<Statistics> CreateCourseStatistics(string userLogin, int courseId);
        Statistics UpdateStatistics(Statistics statistics);
        Statistics DeleteStatistics(int statisticsId);
    }
}
