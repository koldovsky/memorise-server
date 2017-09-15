using System.Web.Http;
using MemoBll;
using MemoDTO;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;

namespace MemoRise.Controllers
{

    public class CatalogController : ApiController
    {
        CatalogBll catalog = new CatalogBll();

        [HttpGet]
        public HttpResponseMessage GetCategories()
        {
            try
            {
                List<CategoryDTO> categories = catalog.GetAllCategories();
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Categories collection is empty. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetCourses()
        {
            try
            {
                List<CourseDTO> courses = catalog.GetAllCourses();
                return Request.CreateResponse(HttpStatusCode.OK, courses); 
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Courses collection is empty. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetDecks()
        {
            try
            {
                List<DeckDTO> decks = catalog.GetAllDecks();
                return Request.CreateResponse(HttpStatusCode.OK, decks); 
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Decks collection is empty. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }
        }

        [HttpGet]
        [Route("Catalog/GetCoursesByCategory/{categoryName}")]
        public HttpResponseMessage GetCoursesByCategory(string categoryName)
        {
            try
            {
                List<CourseDTO> courses = catalog.GetAllCourseByCategory(categoryName);
                return Request.CreateResponse(HttpStatusCode.OK, courses);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Category with name = {categoryName} not found. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }
        }

        [HttpGet]
        [Route("Catalog/GetDecksByCategory/{categoryName}")]
        public HttpResponseMessage GetDecksByCategory(string categoryName)
        {
            try
            {
                List<DeckDTO> decks = catalog.GetAllDecksByCategory(categoryName);
                return Request.CreateResponse(HttpStatusCode.OK, decks);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Category with name = {categoryName} not found. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }

        }
               

        [HttpGet]
        [Route("Catalog/GetAllDecksByCourse/{courseName}")]
        public HttpResponseMessage GetAllDecksByCourse(string courseName)
        {
            try
            {
                List<DeckDTO> decks = catalog.GetAllDecksByCourse(courseName);
                return Request.CreateResponse(HttpStatusCode.OK, decks);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Course with name = {courseName} not found. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch(Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }

        }

        [HttpGet]
        [Route("Catalog/GetCourse/{courseName}")]
        public HttpResponseMessage GetCourse (string courseName)
        {
            try
            {
                CourseWithDecksDTO course = catalog.GetCourseWithDecksDTO(courseName);
                return Request.CreateResponse(HttpStatusCode.OK, course);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Course with name = {courseName} not found. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }
        }

    }
}
