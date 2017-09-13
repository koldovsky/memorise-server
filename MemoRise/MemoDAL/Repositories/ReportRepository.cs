using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class ReportRepository: BaseRepository<Report>
    {
        public ReportRepository(MemoContext context):base(context)
        {

        }
    }
}