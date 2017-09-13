using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>
    {
        public AnswerRepository(MemoContext context):base(context)
        {
            
        }
    }
}