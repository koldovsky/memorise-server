using System;
using System.Web.Http;
using MemoBll.Managers;
using MemoDTO;

namespace MemoRise.Controllers
{
    public class StatisticsController : ApiController
    {
        UserStatisticsBll statistics = new UserStatisticsBll();

        [HttpGet]
        [Route("Statistics/GetStatistics/{userLogin}/{cardId}")]
        public IHttpActionResult GetStatistics(string userLogin, int cardId)
        {
            try
            {
                var response = statistics.GetStatistics(userLogin, cardId);
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
        [Route("Statistics/GetDeckStatistics/{userLogin}/{deckId}")]
        public IHttpActionResult GetDeckStatistics(
            string userLogin, 
            int deckId)
        {
            try
            {
                var response = statistics
                    .GetDeckStatistics(userLogin, deckId);
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
        [Route("Statistics/GetCourseStatistics/{userLogin}/{courseId}")]
        public IHttpActionResult GetCourseStatistics(
            string userLogin, 
            int courseId)
        {
            try
            {
                var response = statistics.GetCourseStatistics(userLogin, courseId);
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
        public IHttpActionResult CreateStatistics(StatisticsDTO statisticsDto)
        {
            try
            {
                var response = statistics.CreateStatistics(statisticsDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateDeckStatistics(
            SubscriptionStatisticsDTO statisticsDto)
        {
            try
            {
                var response = statistics.CreateDeckStatistics(
                    statisticsDto.UserLogin,
                    statisticsDto.ItemId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateCourseStatistics(
            SubscriptionStatisticsDTO statisticsDto)
        {
            try
            {
                var response = statistics.CreateCourseStatistics(
                    statisticsDto.UserLogin, 
                    statisticsDto.ItemId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateStatistics(StatisticsDTO statisticsDto)
        {
            try
            {
                var response = statistics.UpdateStatistics(statisticsDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Statistics/DeleteStatistics/{statisticsId}")]
        public IHttpActionResult DeleteStatistics(int statisticsId)
        {
            try
            {
                var response = statistics.DeleteStatistics(statisticsId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
