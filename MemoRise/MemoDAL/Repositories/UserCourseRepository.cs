using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class UserCourseRepository: BaseRepository<UserCourse>
    {
        public UserCourseRepository(MemoContext context):base(context)
        {

        }
    }
}