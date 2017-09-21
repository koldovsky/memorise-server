using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    class CustomerCourse
    {
        IUnitOfWork unitOfWork;

        public CustomerCourse()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public CustomerCourse(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Course GetCourse(int courseId)
        {
            return unitOfWork.Courses.Get(courseId);
        }
    }
}
