using System.Web.Http;
using MemoBll;
using MemoDTO;
using System.Collections.Generic;
using System;
using MemoBll.Managers;
using System.Linq;
using MemoRise.Helpers;
using System.Configuration;
using FlickrNet;
using PagedList;
using PagedList.Mvc;

namespace MemoRise.Controllers
{
    public class CatalogController : ApiController
    {
        CatalogBll catalog = new CatalogBll();

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            try
            {
                List<CategoryDTO> categories = catalog.GetAllCategories()
                                               .ToList();
                return Ok(categories);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Categories collection is empty.";
                return BadRequest(ex.Message);
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
                List<CourseDTO> courses = catalog.GetAllCourses().ToList();
                PhotoUrlLoader.LoadCoursesPhotos(courses);
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
        [Route("Catalog/GetCoursesByPage/{page}/{pageSize}")]
        public IHttpActionResult GetCoursesByPage(int page, int pageSize)
        {
            try
            {
                List<CourseDTO> courses;
                if (page == 0 && pageSize == 0)
                {
                    courses = catalog.GetAllCourses().ToList();
                }
                else
                {
                    courses = catalog.GetAllCourses().Skip((page - 1) * pageSize).Take(pageSize).ToList();
                }
                var temp = new { items = courses, totalCount = courses.Count };
                return Ok(temp);
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
        //[Authorize(Roles = "Customer")]
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
        [Route("Catalog/GetDecksByPage/{page}/{pageSize}")]
        public IHttpActionResult GetDecksByPage(int page, int pageSize)
        {
            try
            {
                List<DeckDTO> decks;
                if (page == 0 && pageSize == 0)
                {
                    decks = catalog.GetAllDecks().ToList();
                }
                else
                {
                    decks = catalog.GetAllDecks().Skip((page - 1) * pageSize).Take(pageSize).ToList();
                }
                var temp = new { items = decks, totalCount = decks.Count };
                return Ok(temp);
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

        //[HttpGet]

        //public IHttpActionResult GetSortedDecks()
        //{
        //    try
        //    {
        //        IEnumerable<DeckDTO> decks = catalog.GetAllDecks().OrderBy(s => s.Name);

        //        return Ok();
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        var message = $"Decks collection is empty. {ex.Message}";
        //        return BadRequest(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

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
