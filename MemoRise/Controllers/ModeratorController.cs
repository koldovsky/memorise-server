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
        public IHttpActionResult CreateCategory(CategoryDTO categoryDto)
        {
            try
            {
                Category course = converter.ConvertToCategory(categoryDto);
                moderation.CreateCategory(course);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
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
        [Route("Moderator/DeleteCategory/{categoryId}")]
        public IHttpActionResult DeleteCategory(int categoryId)
        {
            try
            {
                moderation.RemoveCategory(categoryId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateCourse(CourseDTO courseDto)
        {
            try
            {
                Course course = converter.ConvertToCourse(courseDto);
                moderation.CreateCourse(course);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
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
        [Route("Moderator/DeleteCourse/{courseId}")]
        public IHttpActionResult DeleteCourse(int courseId)
        {
            try
            {
                moderation.RemoveCourse(courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateDeck(DeckDTO deckDto)
        {
            try
            {
                Deck deck = converter.ConvertToDeck(deckDto);
                moderation.CreateDeck(deck);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
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
        [Route("Moderator/DeleteDeck/{deckId}")]
        public IHttpActionResult DeleteDeck(int deckId)
        {
            try
            {
                moderation.RemoveDeck(deckId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
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
