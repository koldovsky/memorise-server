using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class StatisticsRepository : 
        BaseRepository<Statistics>, 
        IStatisticsRepository
    {
        public StatisticsRepository(MemoContext context) : base(context)
        {
        }
    }
}