using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using System.Diagnostics.CodeAnalysis;

namespace MemoBll
{
    public class Filter
    {
        IUnitOfWork unitOfWork;

        [ExcludeFromCodeCoverage]
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
