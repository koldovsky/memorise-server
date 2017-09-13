using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class StatisticRepository: BaseRepository<Statistic>
    {
        public StatisticRepository(MemoContext context):base(context)
        {

        }
    }
}