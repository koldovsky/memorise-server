using MemoDTO;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoBll.Managers;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Data;
using System.Linq;
using System.Reflection;
using MemoRise.Models;

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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult GetSearchCardsByDeckLinking([FromBody]SearchDataModel searchDataModel)  
        {
            int totalCount = 0;
            try
            {
                IEnumerable<CardDTO> cards = quiz.GetCardsByDeck(searchDataModel.DeckLinking);
                if (!string.IsNullOrEmpty(searchDataModel.SearchString))
                {
                    cards = cards.Where(card => card.Question.ToLower().Contains(searchDataModel.SearchString.ToLower()));
                }

                totalCount = cards.Count();
                cards = searchDataModel.Sort ? cards.OrderByDescending(name => name.CardType.Name) : cards.OrderBy(name => name.CardType.Name);

                if (searchDataModel.Page == 1 && searchDataModel.PageSize == 0)
                {
                    cards = cards.ToList();
                }
                else
                {
                    cards = cards.Skip((searchDataModel.Page - 1) * searchDataModel.PageSize)
                                 .Take(searchDataModel.PageSize)
                                 .ToList();
                }

                var temp = new { items = cards, totalCount = totalCount };
                return Ok(temp);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Cards collection is empty. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Quiz/GetCardsByDeckArray/{deckLink}")]
        public HttpResponseMessage GetCardsByDeckArray(string deckLink)
        {
            var arrayOfLinks = deckLink.Split(',');
            try
            {
                List<CardDTO> cards = quiz.GetCardsByDeckArray(arrayOfLinks);
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
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

        [HttpPost]
        public IHttpActionResult CodeAnswer(CodeAnswerDTO codeAnswerDTO)
        {
            try
            {
                var provider = new CSharpCodeProvider();
                var cp = new CompilerParameters
                {
                    GenerateInMemory = true,
                };

                string code = codeAnswerDTO.CodeAnswerText;
                var compileResult = provider.CompileAssemblyFromSource(cp, code);

                if (compileResult.Errors.Count > 0)
                {
                    codeAnswerDTO.CodeAnswerText = "ERROR\r\n";
                    compileResult.Errors.Cast<CompilerError>().ToList()
                    .ForEach(error => codeAnswerDTO.CodeAnswerText += error.ErrorText + "\r\n");
                    codeAnswerDTO.IsRight = false;
                }
                else
                {
                    codeAnswerDTO.CodeAnswerText = "Compile succeeded \r\n";

                    var calcType = compileResult.CompiledAssembly.GetType("Quiz");
                    var calc = Activator.CreateInstance(calcType);

                    int actualResult = (int)calcType.InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { 0, 0 });
                    int expectedResult = 0;
                    int actualResult2 = (int)calcType.InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { -5, 7 });
                    int expectedResult2 = 2;
                    int actualResult3 = (int)calcType.InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { 10, 130 });
                    int expectedResult3 = 140;
                    int actualResult4 = (int)calcType.InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { 4, -54 });
                    int expectedResult4 = -50;
                    int actualResult5 = (int)calcType.InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { -4, -54 });
                    int expectedResult5 = -58;

                    if (actualResult == expectedResult &&
                        actualResult2 == expectedResult2 &&
                        actualResult3 == expectedResult3 &&
                        actualResult4 == expectedResult4 &&
                        actualResult5 == expectedResult5)
                    {
                        codeAnswerDTO.CodeAnswerText += "Right";
                        codeAnswerDTO.IsRight = true;
                    }
                    else
                    {
                        codeAnswerDTO.CodeAnswerText += "Wrong";
                        codeAnswerDTO.IsRight = false;
                    }
                }
                return Ok(codeAnswerDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}