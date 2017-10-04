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
        public IHttpActionResult GetCardsByDeck(string deckName)
        {
            try
            {
                List<CardDTO> cards = quiz.GetCardsByDeck(deckName);
                return Ok(cards);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Deck with name = {deckName} not found. {ex.Message}";
                return BadRequest(message);
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