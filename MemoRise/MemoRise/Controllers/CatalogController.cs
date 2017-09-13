using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using MemoDTO;
using System.Collections.Generic;

namespace MemoRise.Controllers
{

    public class CatalogController : ApiController
    {
       
        CatalogBll catalog = new CatalogBll();

        [HttpGet]
        public List<CategoryDTO> GetCategories()
        {
                List<CategoryDTO> categories = catalog.GetAllCategories();
                return categories;
        }

        [HttpGet]
        public List<CourseDTO> GetCourses()
        {
            List<CourseDTO> courses = catalog.GetAllCourses();
            return courses;
        }

        [HttpGet]
        public List<DeckDTO> GetDecks()
        {
            List<DeckDTO> decks = catalog.GetAllDecks();
            return decks;
        }

        [HttpGet]
        public List<CourseDTO> GetCoursesByCategory(string categoryName)
        {
            return catalog.GetAllCourseByCategory(categoryName);
             
        }

        [HttpGet]
        public List<DeckDTO> GetDecksByCategory(string categoryName)
        {
            return catalog.GetAllDecksByCategory(categoryName);
            
        }

        [HttpGet]
        public List<DeckDTO> GetAllDecksByCourse(string courseName)
        {
            return catalog.GetAllDecksByCourse(courseName);
            
        }

    }
}
