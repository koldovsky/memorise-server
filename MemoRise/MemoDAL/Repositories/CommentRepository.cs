using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class CommentRepository: BaseRepository<Comment>
    {
        public CommentRepository(MemoContext context):base(context)
        {

        }
    }
}