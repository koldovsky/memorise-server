using System;
using System.Web.Http;
using MemoBll.Managers;
using MemoDTO;

namespace MemoRise.Controllers
{
    public class UserSubscriptionsController: ApiController
    {
        private UserSubscriptionsBll userSubscriptions = new UserSubscriptionsBll();

        [HttpGet]
        [Route("UserSubscriptions/GetSubscribedCourses/{userName}")]
        public IHttpActionResult GetSubscribedCourses(string userName)
        {
            try
            {
                var courses = userSubscriptions
                    .GetSubscribedCourses(userName);
                return Ok(courses);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("UserSubscriptions/GetSubscribedDecks/{userName}")]
        public IHttpActionResult GetSubscribedDecks(string userName)
        {
            try
            {
                var decks = userSubscriptions
                    .GetSubscribedDecks(userName);
                return Ok(decks);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("UserSubscriptions/GetCoursesSubscriptions/{userName}")]
        public IHttpActionResult GetCoursesSubscriptions(string userName)
        {
            try
            {
                var subscriptions = userSubscriptions
                    .GetCoursesSubscriptions(userName);
                return Ok(subscriptions);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("UserSubscriptions/GetDecksSubscriptions/{userName}")]
        public IHttpActionResult GetDecksSubscriptions(string userName)
        {
            try
            {
                var subscriptions = userSubscriptions
                    .GetDecksSubscriptions(userName);
                return Ok(subscriptions);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserSubscriptions/CreateCourseSubscriptions/{userName}/{courseId}")]
        public IHttpActionResult CreateCourseSubscriptions(string userName, int courseId)
        {
            try
            {
                userSubscriptions.CreateCourseSubscription(userName, courseId);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UserSubscriptions/CreateDeckSubscriptions/{userName}/{deckId}")]
        public IHttpActionResult CreateDeckSubscriptions(string userName, int deckId)
        {
            try
            {
                userSubscriptions.CreateDeckSubscription(userName, deckId);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateCourseSubscriptions(
            SubscribedCourseDTO subscribedCourse)
        {
            try
            {
                userSubscriptions.UpdateCourseSubscription(subscribedCourse);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateDeckSubscriptions(
            SubscribedDeckDTO subscribedDeck)
        {
            try
            {
                userSubscriptions.UpdateDeckSubscribtion(subscribedDeck);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("UserSubscriptions/CreateCourseSubscriptions/{subscriptionId}")]
        public IHttpActionResult DeleteCourseSubscriptions(int subscriptionId)
        {
            try
            {
                userSubscriptions.DeleteCourseSubsription(subscriptionId);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("UserSubscriptions/CreateDeckSubscriptions/{subscriptionId}")]
        public IHttpActionResult DeleteDeckSubscriptions(int subscriptionId)
        {
            try
            {
                userSubscriptions.DeleteDeckSubscription(subscriptionId);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}