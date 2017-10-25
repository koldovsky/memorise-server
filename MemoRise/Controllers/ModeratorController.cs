using System;
using System.Web.Http;
using MemoDTO;
using MemoBll.Managers;
using MemoBll.Logic;
using MemoDAL.Entities;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MemoRise.Controllers
{
    public class ModeratorController : ApiController
    {
        ModerationBll moderation = new ModerationBll();
        ConverterFromDTO converter = new ConverterFromDTO();
        ConverterToDTO converterToDTO = new ConverterToDTO();

        #region Categories

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateCategory(CategoryDTO categoryDTO)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Category category = converter.ConvertToCategory(categoryDTO);
                moderation.CreateCategory(category);
                return Ok(moderation.FindCategoryDTOByName(categoryDTO.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Category category = moderation.FindCategoryAndUpdateValues(categoryDTO);
                moderation.UpdateCategory(category);
                return Ok(categoryDTO);
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

        [HttpGet]
        [Authorize]
        [Route("Moderator/FindCategoryByName/{categoryName}")]
        public IHttpActionResult FindCategoryByName(string categoryName)
        {
            try
            {
                categoryName = Encoding.UTF8.GetString(
                              Convert.FromBase64String(categoryName));
                var category = moderation.FindCategoryDTOByName(categoryName);
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

        [HttpGet]
        [Authorize]
        [Route("Moderator/FindCategoryByLinking/{categoryLinking}")]
        public IHttpActionResult FindCategoryByLinking(string categoryLinking)
        {
            try
            {
                
                var category = moderation.FindCategoryByLinking(categoryLinking);
                return Ok(category);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Courses

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateCourse(CourseDTO courseDTO)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Course course = converter.ConvertToCourse(courseDTO);
                course.Category = moderation
                    .FindCategoryByName(courseDTO.CategoryName);
                moderation.CreateCourse(course);
                return Ok(moderation.FindCourseDTOByName(courseDTO.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateCourse(CourseWithDecksDTO courseDTO)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Course course = moderation.FindCourseAndUpdateValues(courseDTO);
                moderation.UpdateCourse(course);

                return Ok(courseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
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
                courseName = Encoding.UTF8.GetString(
                              Convert.FromBase64String(courseName));
                var course = moderation.FindCourseDTOByName(courseName);
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
        #endregion

        #region Decks

        [HttpGet]
        [Authorize]
        [Route("Moderator/FindDeckByName/{deckName}")]
        public IHttpActionResult FindDeckByName(string deckName)
        {
            try
            {
                deckName = Encoding.UTF8.GetString(
                             Convert.FromBase64String(deckName));
                var deck = moderation.FindDeckDTOByName(deckName);
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
        

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateDeck(DeckDTO deckDTO)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Deck deck = converter.ConvertToDeck(deckDTO);
                deck.Category = moderation
                    .FindCategoryByName(deckDTO.CategoryName);
                moderation.CreateDeck(deck);
                return Ok(moderation.FindDeckDTOByName(deckDTO.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateDeck(DeckDTO deckDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Deck deck = moderation.FindDeckAndUpdateValues(deckDTO);
                moderation.UpdateDeck(deck);

                return Ok(deckDTO);
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

        #endregion
        
        #region Cards

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateCard(CardDTO cardDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Card card = converter.ConvertToCard(cardDTO);
                card.Deck = moderation.FindDeckByName(cardDTO.DeckName);
                card.CardType = moderation.FindCardTypeByName(cardDTO.CardTypeName);
                card.Answers = new List<Answer>();
                foreach(var answer in cardDTO.Answers)
                {
                    card.Answers.Add(moderation.CreateAnswer(converter.ConvertToAnswer(answer)));
                }
                moderation.CreateCard(card);
                return Ok(converterToDTO.ConvertToCardDTO(card));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize()]
        public IHttpActionResult UpdateCard(CardDTO cardDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Card card = moderation.FindCardAndUpdateValues(cardDTO);
                moderation.UpdateCard(card);
                return Ok(cardDTO);
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
                return Ok(cardId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetCardsType()
        {
            try
            {
                List<CardTypeDTO> cardTypes = moderation.GetAllCardTypes()
                    .ToList();
                                               
                return Ok(cardTypes);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"CardsType collection is empty. {ex.Message}";
                return BadRequest(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Moderator/GetCardById/{cardId}")]
        public IHttpActionResult GetCardById(int cardId)
        {
            try
            {
                CardDTO cardDto =  moderation.GetCardById(cardId);
                return Ok(cardDto);
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
        #endregion

    }
}
