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
        [Route("UserSubscriptions/GetCourseSubscriptions/{userName}")]
        public IHttpActionResult GetCourseSubscriptions(string userName)
        {
            try
            {
                var subscriptions = userSubscriptions
                    .GetCourseSubscriptions(userName);
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
        [Route("UserSubscriptions/GetDeckSubscriptions/{userName}")]
        public IHttpActionResult GetDeckSubscriptions(string userName)
        {
            try
            {
                var subscriptions = userSubscriptions
                    .GetDeckSubscriptions(userName);
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
        [Route("UserSubscriptions/CreateCourseSubscription/{userName}/{courseId}")]
        public IHttpActionResult CreateCourseSubscription(string userName, int courseId)
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
        [Route("UserSubscriptions/CreateDeckSubscription/{userName}/{deckId}")]
        public IHttpActionResult CreateDeckSubscription(string userName, int deckId)
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
        public IHttpActionResult UpdateCourseSubscription(
            CourseSubscriptionDTO courseSubscription)
        {
            try
            {
                userSubscriptions.UpdateCourseSubscription(courseSubscription);
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
        public IHttpActionResult UpdateDeckSubscription(
            DeckSubscriptionDTO deckSubscription)
        {
            try
            {
                userSubscriptions.UpdateDeckSubscribtion(deckSubscription);
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
        [Route("UserSubscriptions/DeleteCourseSubscription/{subscriptionId}")]
        public IHttpActionResult DeleteCourseSubscription(int subscriptionId)
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
        [Route("UserSubscriptions/DeleteDeckSubscription/{subscriptionId}")]
        public IHttpActionResult DeleteDeckSubscription(int subscriptionId)
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