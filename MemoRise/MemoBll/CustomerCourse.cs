using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class CustomerCourse
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        public Course GetCourse(int courseId)
        {
            return unitOfWork.Course.Get(courseId);
        }
    }
}
