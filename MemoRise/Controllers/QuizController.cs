﻿using MemoBll.Logic;
using MemoBll.Managers;
using MemoDAL.Entities;
using MemoDTO;
using MemoRise.Helpers;
using MemoRise.Models;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoRise.Controllers
{
    public class QuizController : ApiController
    {
        private QuizBll quiz = new QuizBll();
        private UserStatistics statistics = new UserStatistics();
        private UserSubscriptionsBll userSubscriptions = new UserSubscriptionsBll();
        private ModerationBll moderation = new ModerationBll();
        private CatalogBll catalogBll = new CatalogBll();

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

        [HttpGet]
        [Authorize]
        [Route("Quiz/GetCardsForSubscribedCourse/{courseLink}/{numberOfCards}/{userLogin}")]
        public IHttpActionResult GetCardsForSubscribedCourse(string courseLink, int numberOfCards, string userLogin)
        {
            try
            {
                CourseDTO currentCourse = moderation.FindCourseByLinking(courseLink);

                IEnumerable<Statistics> courseStatistics = statistics.GetCourseStatistics(userLogin, currentCourse.Id);

                if (numberOfCards > courseStatistics.Count())
                {
                    numberOfCards = courseStatistics.Count();
                }
                
                List<CardDTO> cards = quiz.GetCardsForSubscription(numberOfCards, courseStatistics);
                
                return Ok(cards);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Course with link = {courseLink} not found. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Quiz/GetCardsForSubscribedDeck/{deckLink}/{numberOfCards}/{userLogin}")]
        public IHttpActionResult GetCardsForSubscribedDeck(string deckLink, int numberOfCards, string userLogin)
        {
            try
            {
                DeckDTO currentDeck = moderation.FindDeckByLinking(deckLink);

                IEnumerable<Statistics> deckStatistics = statistics.GetDeckStatistics(userLogin, currentDeck.Id);

                if (numberOfCards > deckStatistics.Count())
                {
                    numberOfCards = deckStatistics.Count();
                }

                List<CardDTO> cards = quiz.GetCardsForSubscription(numberOfCards, deckStatistics);

                return Ok(cards);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Deck with name = {deckLink} not found. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Quiz/GetDecksNeedToRepeat/{userLogin}")]
        public IHttpActionResult GetDecksNeedToRepeat(string userLogin)
        {
            try
            {
                List<DeckDTO> decksNeedToRepeat = new List<DeckDTO>();

                List<DeckSubscriptionDTO> deckSubscriptionDTOs = new List<DeckSubscriptionDTO>();

                deckSubscriptionDTOs = userSubscriptions.GetDeckSubscriptions(userLogin).ToList();

                deckSubscriptionDTOs.ForEach(deckSub =>
                {
                    if (quiz.GetCardsForRepeat(statistics.GetDeckStatistics(userLogin, deckSub.DeckId)).Count() > 0)
                    {
                        decksNeedToRepeat.Add(catalogBll.GetDeckDTO(deckSub.DeckId));
                    }
                });

                return Ok(decksNeedToRepeat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Quiz/GetCoursesNeedToRepeat/{userLogin}")]
        public IHttpActionResult GetCoursesNeedToRepeat(string userLogin)
        {
            try
            {
                List<CourseDTO> coursesNeedToRepeat = new List<CourseDTO>();

                List<CourseSubscriptionDTO> courseSubscriptionDTOs = new List<CourseSubscriptionDTO>();

                courseSubscriptionDTOs = userSubscriptions.GetCourseSubscriptions(userLogin).ToList();

                courseSubscriptionDTOs.ForEach(courseSub =>
                {
                    if (quiz.GetCardsForRepeat(statistics.GetCourseStatistics(userLogin, courseSub.CourseId)).Count() > 0)
                    {
                        coursesNeedToRepeat.Add(catalogBll.GetCourseDTO(courseSub.CourseId));
                    }
                });

                return Ok(coursesNeedToRepeat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult ChangeAlgorithm(AlgorithmDTO algorithm)
        {
            try
            {
                quiz.ChangeAlgorithm(algorithm);

                return Ok(algorithm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
        public IHttpActionResult CodeAnswerCheck(CodeAnswerDTO codeAnswerDTO)
        {
            try
            {
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters cp = new CompilerParameters
                {
                    GenerateInMemory = true,
                };

                string code = codeAnswerDTO.CodeAnswerText;
                CompilerResults compileResult = provider.CompileAssemblyFromSource(cp, code);

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
                    CodeAnswerTests codeAnswerTests = new CodeAnswerTests();
                    bool isAnswerRight = codeAnswerTests.IsAnswerRight(codeAnswerDTO.CardId, compileResult);
                    if (isAnswerRight)
                    {
                        codeAnswerDTO.CodeAnswerText += "Your answer is correct";
                        codeAnswerDTO.IsRight = true;
                    }
                    else
                    {
                        codeAnswerDTO.CodeAnswerText += "Your answer is uncorrect";
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
