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
        [Route("Quiz/GetCardsByDeck/{deckName}")]
        public HttpResponseMessage GetCardsByDeck(string deckName)
        {
            try
            {
                List<CardDTO> cards = quiz.GetCardsByDeck(deckName);
                return Request.CreateResponse(HttpStatusCode.OK, cards);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Deck with name = {deckName} not found. {ex.Message}";
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
        [Route("Quiz/IsAnswerCorrect/{cardId:int}/{answerText}")]
        public HttpResponseMessage IsAnswerCorrect(int cardId, string answerText)
        {
            try
            {
                bool isCorrect = quiz.IsAnswerCorrect(cardId, answerText);
                return Request.CreateResponse(HttpStatusCode.OK, isCorrect);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Card with id = {cardId} not found. {ex.Message}";
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