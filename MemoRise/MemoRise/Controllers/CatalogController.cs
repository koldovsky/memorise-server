using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using MemoDTO;
using System;
using System.Collections.Generic;

namespace MemoRise.Controllers
{

    public class CatalogController : ApiController
    {

        CatalogBll catalog = new CatalogBll();
        public List<CategoryDTO> GetCategories()
        {
                List<CategoryDTO> categories = catalog.GetAllCategories();
                return categories;
        }
       
        
        public List<CourseDTO> GetCourses()
        {
            List<CourseDTO> courses = catalog.GetAllCourses();
            return courses;
        }
        public List<DeckDTO> GetDecks()
        {
            List<DeckDTO> decks = catalog.GetAllDecks();
            return decks;
        }
        public string GetCoursesByCategory(string categoryName)
        {
            var decks = JsonConvert.SerializeObject(catalog.GetAllCourseByCategory(categoryName));
            return decks;
        }
        public string GetDecksByCategory(string categoryName)
        {
            var decks = JsonConvert.SerializeObject(catalog.GetAllDecksByCategory(categoryName));
            return decks;
        }
        public string GetAllDecksByCourse(string courseName)
        {
            var decks = JsonConvert.SerializeObject(catalog.GetAllDecksByCourse(courseName));
            return decks;
        }

    }
}
