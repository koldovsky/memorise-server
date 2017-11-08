using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class AlgorithmRepository : BaseRepository<Algorithm>, IAlgorithmRepository
    {
        public AlgorithmRepository(MemoContext context) : base(context)
        {
        }
    }
}
