using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class CourseSubscriptionsRepository : 
        BaseRepository<CourseSubscription>,
        ICourseSubscriptionRepository
    {
        public CourseSubscriptionsRepository(MemoContext context) : base(context)
        {
        }
    }
}