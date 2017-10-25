using System;
using System.Web.Http;
using MemoBll.Managers;
using MemoDTO;

namespace MemoRise.Controllers
{
    [Authorize]
    public class SubscriptionsController : ApiController
    {
        private UserSubscriptionsBll userSubscriptions = new UserSubscriptionsBll();

        [HttpGet]
        [Route("Subscriptions/GetSubscribedCourses/{userLogin}")]
        public IHttpActionResult GetSubscribedCourses(string userLogin)
        {
            try
            {
                var response = userSubscriptions
                    .GetSubscribedCourses(userLogin);
                return Ok(response);
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
        [Route("Subscriptions/GetSubscribedDecks/{userLogin}")]
        public IHttpActionResult GetSubscribedDecks(string userLogin)
        {
            try
            {
                var response = userSubscriptions
                    .GetSubscribedDecks(userLogin);
                return Ok(response);
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
        [Route("Subscriptions/GetCourseSubscriptions/{userLogin}")]
        public IHttpActionResult GetCourseSubscriptions(string userLogin)
        {
            try
            {
                var response = userSubscriptions
                    .GetCourseSubscriptions(userLogin);
                return Ok(response);
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
        [Route("Subscriptions/GetDeckSubscriptions/{userLogin}")]
        public IHttpActionResult GetDeckSubscriptions(string userLogin)
        {
            try
            {
                var response = userSubscriptions
                    .GetDeckSubscriptions(userLogin);
                return Ok(response);
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
        public IHttpActionResult CreateCourseSubscription(
            CourseSubscriptionDTO subscription)
        {
            try
            {
                var response = userSubscriptions
                    .CreateCourseSubscription(
                    subscription.UserLogin, 
                    subscription.CourseId);
                return Ok(response);
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
        public IHttpActionResult CreateDeckSubscription(
            DeckSubscriptionDTO subscription)
        {
            try
            {
                var response = userSubscriptions.CreateDeckSubscription(
                    subscription.UserLogin,
                    subscription.DeckId);
                return Ok(response);
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
                var response = userSubscriptions
                    .UpdateCourseSubscription(courseSubscription);
                return Ok(response);
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
                var response = userSubscriptions
                    .UpdateDeckSubscribtion(deckSubscription);
                return Ok(response);
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

        [Authorize]
        [Route("Subscriptions/DeleteCourseSubscription/{subscriptionId}")]
        public IHttpActionResult DeleteCourseSubscription(int subscriptionId)
        {
            try
            {
                var response = userSubscriptions
                    .DeleteCourseSubsription(subscriptionId);
                return Ok(response);
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
        [Route("Subscriptions/DeleteDeckSubscription/{subscriptionId}")]
        public IHttpActionResult DeleteDeckSubscription(int subscriptionId)
        {
            try
            {
                var response = userSubscriptions
                    .DeleteDeckSubscription(subscriptionId);
                return Ok(response);
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