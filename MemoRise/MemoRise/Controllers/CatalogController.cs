using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using System.Web.Script.Serialization;

namespace MemoRise.Controllers
{

    public class CatalogController : ApiController
    {
        CatalogBll catalog = new CatalogBll();
        public string GetCategories()
        {
            var categories = catalog.GetAllCategories();
            var serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(categories);
            return jsonResult;
            //try
            //{
            //    var categories = JsonConvert.SerializeObject(catalog.GetAllCategories());
            //    return categories;
            //}
            //catch(ArgumentNullException ex)
            //{
            //    return ex.Message;
            //}
            //catch(NullReferenceException ex)
            //{
            //    return ex.Message;
            //}
            //catch(Exception ex)
            //{
            //    return ex.Message;
            //}
        }
        
        public string GetCourses()
        {
            var courses = JsonConvert.SerializeObject(catalog.GetAllCourses());
            return courses;
        }
        public string GetDecks()
        {
            var decks = JsonConvert.SerializeObject(catalog.GetAllDecks());
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
