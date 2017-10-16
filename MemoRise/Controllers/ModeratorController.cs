using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoDTO;
using MemoBll.Managers;
using MemoBll.Logic;
using MemoDAL.Entities;

namespace MemoRise.Controllers
{

    public class ModeratorController : ApiController
    {
        ModerationBll moderation = new ModerationBll();
        ConverterFromDto converter = new ConverterFromDto();

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateCategory(CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Category category = converter.ConvertToCategory(categoryDto);
                moderation.CreateCategory(category);
                return Ok(moderation.FindCategoryByNameDTO(categoryDto.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateCategory(CategoryDTO categoryDto)
        {
            try
            {
                Category category = converter.ConvertToCategory(categoryDto);
                moderation.UpdateCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("Moderator/DeleteCategory/{categoryId}")]
        public IHttpActionResult DeleteCategory(int categoryId)
        {
            try
            {
                moderation.RemoveCategory(categoryId);
                return Ok(categoryId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        //[Authorize]
        public IHttpActionResult CreateCourse(CourseDTO courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Course course = converter.ConvertToCourse(courseDto);
                course.Category = moderation
                    .FindCategoryByName(courseDto.CategoryName);
                moderation.CreateCourse(course);
                return Ok(moderation.FindCourseByName(courseDto.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        //[Authorize]
        public IHttpActionResult UpdateCourse(CourseDTO courseDto)
        {
            try
            {
                Course course = converter.ConvertToCourse(courseDto);
                moderation.UpdateCourse(course);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        [Route("Moderator/DeleteCourse/{courseId}")]
        public IHttpActionResult DeleteCourse(int courseId)
        {
            try
            {
                moderation.RemoveCourse(courseId);
                return Ok(courseId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("Moderator/FindCourseByName/{courseName}")]
        public IHttpActionResult FindCourseByName (string courseName)
        {
            try
            {
                var course = moderation.FindCourseByName(courseName);
                return Ok(course);
            }
            catch (NullReferenceException ex)
            {
                return Ok(new CourseDTO { Name = "unique" });
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("Moderator/FindDeckByName/{deckName}")]
        public IHttpActionResult FindDeckByName(string deckName)
        {
            try
            {
                var deck = moderation.FindDeckByName(deckName);
                return Ok(deck);
            }
            catch (NullReferenceException ex)
            {
                return Ok(new DeckDTO { Name = "unique" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("Moderator/FindCategoryByName/{categoryName}")]
        public IHttpActionResult FindCategoryByName(string categoryName)
        {
            try
            {
                var category = moderation.FindCategoryByNameDTO(categoryName);
                return Ok(category);
            }
            catch (NullReferenceException ex)
            {
                return Ok(new CategoryDTO { Name = "unique" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateDeck(DeckDTO deckDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Deck deck = converter.ConvertToDeck(deckDto);
                deck.Category = moderation
                    .FindCategoryByName(deckDto.CategoryName);
                moderation.CreateDeck(deck);
                return Ok(moderation.FindDeckByName(deckDto.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateDeck(DeckDTO deckDto)
        {
            try
            {
                Deck deck = converter.ConvertToDeck(deckDto);
                moderation.UpdateDeck(deck);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("Moderator/DeleteDeck/{deckId}")]
        public IHttpActionResult DeleteDeck(int deckId)
        {
            try
            {
                moderation.RemoveDeck(deckId);
                return Ok(deckId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Authorize]
        //public IHttpActionResult GetCardsType()
        //{
        //    try
        //    {
        //        List<CardTypeDTO> cardsType = moderation.
        //                                       .ToList();
        //        return Ok(categories);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        var message = $"Categories collection is empty.";
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateCard(CardDTO cardDto)
        {
            try
            {
                Card card = converter.ConvertToCard(cardDto);
                moderation.CreateCard(card);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize()]
        public IHttpActionResult UpdateCard(CardDTO cardDto)
        {
            try
            {
                Card card = converter.ConvertToCard(cardDto);
                moderation.UpdateCard(card);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize()]
        [Route("Moderator/DeleteCard/{cardId}")]
        public IHttpActionResult DeleteCard(int cardId)
        {
            try
            {
                moderation.RemoveCard(cardId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize()]
        public IHttpActionResult CreateAnswer(AnswerDTO answerDto)
        {
            try
            {
                Answer answer = converter.ConvertToAnswer(answerDto);
                moderation.CreateAnswer(answer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize()]
        public IHttpActionResult UpdateAnswer(AnswerDTO answerDto)
        {
            try
            {
                Answer answer = converter.ConvertToAnswer(answerDto);
                moderation.UpdateAnswer(answer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize()]
        [Route("Moderator/DeleteAnswer/{answerId}")]
        public IHttpActionResult DeleteAnswer(int answerId)
        {
            try
            {
                moderation.RemoveAnswer(answerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
