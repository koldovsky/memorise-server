using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class DeckCourseRepository : BaseRepository<DeckCourse>
    {
        public DeckCourseRepository(MemoContext context):base(context)
        {

        }
    }
}