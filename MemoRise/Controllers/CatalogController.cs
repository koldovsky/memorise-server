using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MemoBll.Managers;
using MemoDTO;
using MemoRise.Helpers;

namespace MemoRise.Controllers
{
    public class CatalogController : ApiController
    {
        private CatalogBll catalog = new CatalogBll();

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            try
            {
                List<CategoryDTO> categories = this.catalog.GetAllCategories()
                                               .ToList();
                return this.Ok(categories);
            }
            catch (ArgumentNullException ex)
            {
                var message = "Categories collection is empty.";
                return this.BadRequest(message + ex.Message);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            try
            {
                List<CourseDTO> courses = this.catalog.GetAllCourses().ToList();
                PhotoUrlLoader.LoadCoursesPhotos(courses);
                return this.Ok(courses);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Courses collection is empty. {ex.Message}";
                return this.BadRequest(message);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDecks()
        {
            try
            {
                List<DeckDTO> decks = catalog.GetAllDecks().ToList();
                PhotoUrlLoader.LoadDecksPhotos(decks);

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
                IEnumerable<CourseDTO> courses = catalog.
                                          GetAllCoursesByCategory(categoryName);
                if (courses == null)
                {
                    throw new Exception("Courses aren't found by this category!");
                }
                PhotoUrlLoader.LoadCoursesPhotos(courses);

                return Ok(courses.ToList());
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
                IEnumerable<DeckDTO> decks = catalog
                                     .GetAllDecksByCategory(categoryName);
                if (decks == null)
                {
                    throw new Exception("Decks aren't found by this category!");
                }
                PhotoUrlLoader.LoadDecksPhotos(decks);

                return Ok(decks.ToList());
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
                List<DeckDTO> decks = catalog.GetAllDecksByCourse(courseName)
                                     .ToList();
                PhotoUrlLoader.LoadDecksPhotos(decks);
                return Ok(decks);
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

        [HttpGet]
        [Route("Catalog/GetCourse/{courseName}")]
        public IHttpActionResult GetCourse(string courseName)
        {
            try
            {

                CourseWithDecksDTO course = catalog
                                           .GetCourseWithDecksDTO(courseName);
                PhotoUrlLoader.LoadCourseAndDecksPhotos(course);

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
