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
        
        //public void UpdateAnswer(Answer answer);
        //public  RemoveAnswer(int answerId);


        //void AddCategory(Category category);
        //void UpdateCategory(Category category);
        //void RemoveCategory(int categoryId);

        //void CreateCourse(Course course);
        //void UpdateCourse(Course course);
        //void RemoveCourse(int courseId);

        //void CreateDeck(Deck deck);
        //void UpdateDeck(Deck deck);
        //void RemoveDeck(int deckId);

        //void CreateCard(Card card);
        //void UpdateCard(Card card);
        //void RemoveCard(int cardId);

    }
}
