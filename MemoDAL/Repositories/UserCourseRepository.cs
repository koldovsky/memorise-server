using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class UserCourseRepository: BaseRepository<UserCourse>, IUserCourseRepository
    {
        public UserCourseRepository(MemoContext context) : base(context) { }
    }
}