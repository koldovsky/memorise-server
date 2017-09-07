using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryBll categorybll = new CategoryBll();

        public IEnumerable<Category> GetAllCategories()
        {
            return categorybll.GetAllCategories();
        }

        public Category GetCategory(int id)
        {
            return categorybll.GetCategory(id);
        }

        public void PostCategory(Category item)
        {
            categorybll.AddCategory(item);
        }

        public bool PutCaregory(Category item)
        {
            return categorybll.UpdateCategory(item);
        }

        public void DeleteCaregory(int id)
        {
            categorybll.RemoveCategory(id);
        }

    }
}
