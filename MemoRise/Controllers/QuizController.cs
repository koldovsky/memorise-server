using System.Web.Http;
using MemoBll;
using MemoDTO;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;
using MemoBll.Managers;

namespace MemoRise.Controllers
{
    public class QuizController : ApiController
    {
        QuizBll quiz = new QuizBll();

        [HttpGet]
        [Route("Quiz/GetCardsByCourse/{courseLink}")]
        public HttpResponseMessage GetCardsByCourse(string courseLink)
        {
            try
            {
                List<CardDTO> cards = quiz.GetCardsByCourse(courseLink);
                return Request.CreateResponse(HttpStatusCode.OK, cards);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Course with link = {courseLink} not found. {ex.Message}";
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
        [Route("Quiz/GetCardsByDeck/{deckLink}")]
        public HttpResponseMessage GetCardsByDeck(string deckLink)
        {
            try
            {
                List<CardDTO> cards = quiz.GetCardsByDeck(deckLink);
                return Request.CreateResponse(HttpStatusCode.OK, cards);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Deck with name = {deckLink} not found. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Quiz/IsAnswerCorrect/{cardId:int}/{answerText}")]
        public IHttpActionResult IsAnswerCorrect(int cardId, string answerText)
        {
            try
            {
                bool isCorrect = quiz.IsAnswerCorrect(cardId, answerText);
                return Ok(isCorrect);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Card with id = {cardId} not found. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}