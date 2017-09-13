using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoBll
{
    public class FilterS
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

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
            return unitOfWork.Course.GetAll().ToList();
        }
    }
}
