using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class SubscribedCourseRepository: BaseRepository<SubscribedCourse>, ISubscribedCourseRepository
    {
        public SubscribedCourseRepository(MemoContext context) : base(context) { }
    }
}