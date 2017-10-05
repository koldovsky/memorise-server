using System;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;

namespace MemoBll.Logic
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
            return unitOfWork.Courses.Get(courseId) ?? throw new ArgumentNullException();
        }
    }
}
