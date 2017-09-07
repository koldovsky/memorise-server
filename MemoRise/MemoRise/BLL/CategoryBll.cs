using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemoRise.DAL;

namespace MemoRise.BLL
{
    public class CategoryBll
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Category> GetAllCategories()
        {
            throw new Exception();
        }
        public Category GetCategory(int categoryId)
        {
            throw new Exception();
        }
        public void AddCategory(Category category)
        {
            throw new Exception();
        }
        public bool UpdateCategory(Category category)
        {
            throw new Exception();
        }
        public void RemoveCategory(int categoryId)
        {
            throw new Exception();
        }
    }
}