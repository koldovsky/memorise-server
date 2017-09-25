using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;

namespace MemoBll.Logic
{
    public class Filter
    {
        IUnitOfWork unitOfWork;
		
        public Filter()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public Filter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Category> GetAllCategories()
        {
            return unitOfWork.Categories.GetAll().ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return unitOfWork.Categories.Get(categoryId);
        }

        public List<Course> GetAllCourses()
        {
            return unitOfWork.Courses.GetAll().ToList();
        }
    }
}
