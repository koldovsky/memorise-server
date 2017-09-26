using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(MemoContext context) : base(context) { }
    }
}