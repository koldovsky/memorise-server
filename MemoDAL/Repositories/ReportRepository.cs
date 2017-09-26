using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(MemoContext context) : base(context) { }
    }
}