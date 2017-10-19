using MemoBll.Managers;
using MemoDTO;
using MemoRise.Helpers;
using MemoRise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
                var message = $"Categories collection is empty.";
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult GetCategoriesByPage([FromBody]SearchDataModel searchDataModel) 
        {
            int totalCount = 0;
            try
            {
                IEnumerable<CategoryDTO> categories = catalog.GetAllCategories();
                if (!string.IsNullOrEmpty(searchDataModel.SearchString))
                {
                    categories = categories.Where(category => category.Name.ToLower().Contains(searchDataModel.SearchString.ToLower()));
                }
                totalCount = categories.Count();
                categories = searchDataModel.Sort ? categories.OrderByDescending(name => name.Name) : categories.OrderBy(name => name.Name);

                if (searchDataModel.Page == 1 && searchDataModel.PageSize == 0)
                {
                    categories = categories.ToList();
                }
                else
                {
                    categories = categories.Skip((searchDataModel.Page - 1) * searchDataModel.PageSize)
                                 .Take(searchDataModel.PageSize)
                                 .ToList();
                }
                var temp = new { items = categories, totalCount = totalCount };
                return Ok(temp);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Courses collection is empty. {ex.Message}";
                return BadRequest(message);
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
                List<CourseDTO> courses = catalog.GetAllCourses().ToList();
                //PhotoUrlLoader.LoadCoursesPhotos(courses);
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

        [HttpPost]
        public IHttpActionResult GetCoursesByPage([FromBody]SearchDataModel searchDataModel)    
        {
            int totalCount = 0;
            try
            {
                IEnumerable<CourseDTO> courses = catalog.GetAllCourses();
                if (!string.IsNullOrEmpty(searchDataModel.SearchString))
                {
                    courses = courses.Where(course => course.Name.ToLower().Contains(searchDataModel.SearchString.ToLower()));
                }
                totalCount = courses.Count();
                courses = searchDataModel.Sort ? courses.OrderByDescending(name => name.Name) : courses.OrderBy(name => name.Name);

                if (searchDataModel.Page == 1 && searchDataModel.PageSize == 0)
                {
                    courses = courses.ToList();
                }
                else
                {
                    courses = courses.Skip((searchDataModel.Page - 1) * searchDataModel.PageSize)
                                 .Take(searchDataModel.PageSize)
                                 .ToList();
                }
                var temp = new { items = courses, totalCount = totalCount };
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
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetDecks()
        {
            try
            {
                List<DeckDTO> decks = catalog.GetAllDecks().ToList();
                //PhotoUrlLoader.LoadDecksPhotos(decks);

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

        [HttpPost]
        public IHttpActionResult GetDecksByPage([FromBody]SearchDataModel searchDataModel)
        {
            int totalCount = 0;
            try
            {
                IEnumerable<DeckDTO> decks = catalog.GetAllDecks();
                if (!string.IsNullOrEmpty(searchDataModel.SearchString))
                {
                    decks = decks.Where(deck => deck.Name.ToLower().Contains(searchDataModel.SearchString.ToLower()));
                }
                totalCount = decks.Count();
                decks = searchDataModel.Sort ? decks.OrderByDescending(name => name.Name) : decks.OrderBy(name => name.Name);
                
                if (searchDataModel.Page == 1 && searchDataModel.PageSize == 0)
                {
                    decks = decks.ToList();
                }
                else
                {
                    decks = decks.Skip((searchDataModel.Page - 1) * searchDataModel.PageSize)
                                 .Take(searchDataModel.PageSize)
                                 .ToList();
                }
                var temp = new { items = decks, totalCount = totalCount };
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
        [Route("Catalog/GetDeckByLinking/{linking}")]
        public IHttpActionResult GetDeckByLinking(string linking)
        {
            try
            {
                DeckDTO deck = catalog.GetDeckDTO(linking);
                //PhotoUrlLoader.LoadDecksPhotos(deck);
                return Ok(deck);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"DEck with linking = {linking} " +
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

        //[HttpGet]
        //[Route("Catalog/GetDeckBySearch/{searchString}")]
        //public IHttpActionResult GetDeckBySearch(string searchString)           
        //{
        //    try
        //    {
        //        List<DeckDTO> deck = catalog
        //            .GetAllDecks()
        //            .Where(decks => decks.Name.ToLower().Contains(searchString.ToLower()))
        //            .ToList();

        //        return Ok(deck);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        var message = $"Course with name = {searchString} " +
        //                      $"not found. {ex.Message}";
        //        return BadRequest(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
