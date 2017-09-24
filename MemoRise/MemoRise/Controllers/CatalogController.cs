using System.Web.Http;
using MemoBll;
using MemoDTO;
using System.Collections.Generic;
using System;

namespace MemoRise.Controllers
{

    public class CatalogController : ApiController
    {
        CatalogBll catalog = new CatalogBll();

        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                List<CategoryDTO> categories = catalog.GetAllCategories();
                return  Ok(categories);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Categories collection is empty.";
                return  BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            try
            {
                List<CourseDTO> courses = catalog.GetAllCourses();
                return Ok(courses); 
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Courses collection is empty. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDecks()
        {
            try
            {
                List<DeckDTO> decks = catalog.GetAllDecks();
                return Ok(decks);  
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Decks collection is empty. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Catalog/GetCoursesByCategory/{categoryName}")]
        public IHttpActionResult GetCoursesByCategory(string categoryName)
        {
            try
            {
                List<CourseDTO> courses = catalog.
                                          GetAllCourseByCategory(categoryName);
                return Ok(courses);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Category with name = {categoryName} " +
                              $"not found. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        [HttpGet]
        [Route("Catalog/GetDecksByCategory/{categoryName}")]
        public IHttpActionResult GetDecksByCategory(string categoryName)
        {
            try
            {
                List<DeckDTO> decks = catalog
                                     .GetAllDecksByCategory(categoryName);
                return Ok(decks);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Category with name = {categoryName} " +
                              $"not found. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
               

        [HttpGet]
        [Route("Catalog/GetAllDecksByCourse/{courseName}")]
        public IHttpActionResult GetAllDecksByCourse(string courseName)
        {
            try
            {
                List<DeckDTO> decks = catalog.GetAllDecksByCourse(courseName);
                return Ok(decks);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Course with name = {courseName} " +
                              $"not found. {ex.Message}";
                return BadRequest(message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("Catalog/GetCourse/{courseName}")]
        public IHttpActionResult GetCourse (string courseName)
        {
            try
            {
                CourseWithDecksDTO course = catalog
                                           .GetCourseWithDecksDTO(courseName);
                return Ok(course);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Course with name = {courseName} " +
                              $"not found. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
