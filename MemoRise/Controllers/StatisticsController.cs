using System;
using System.Web.Http;
using MemoBll.Managers;
using MemoDTO;

namespace MemoRise.Controllers
{
    public class StatisticsController : ApiController
    {
        CustomerStatisticsBll statistics = new CustomerStatisticsBll();

        [HttpGet]
        [Route("Statistics/GetStatistics/{userLogin}/{cardId}")]
        public IHttpActionResult GetStatistics(string userLogin, int cardId)
        {
            try
            {
                var statisticsList = statistics.GetStatistics(userLogin, cardId);
                return Ok(statisticsList);
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
        public IHttpActionResult GetDeckStatistics(string userLogin, int deckId)
        {
            try
            {
                var statisticsList = statistics
                    .GetDeckStatistics(userLogin, deckId);
                return Ok(statisticsList);
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
        [Route("Statistics/GetCourseStatistics/{userId}/{courseId}")]
        public IHttpActionResult GetCourseStatistics(string userLogin, int courseId)
        {
            try
            {
                var statisticsList = statistics.GetCourseStatistics(userLogin, courseId);
                return Ok(statisticsList);
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
                statistics.CreateStatistics(statisticsDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Statistics/CreateDeckStatistics/{userLogin}/{deckId}")]
        public IHttpActionResult CreateDeckStatistics(string userLogin, int deckId)
        {
            try
            {
                statistics.CreateDeckStatistics(userLogin, deckId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Statistics/CreateCourseStatistics/{userLogin}/{courseId}")]
        public IHttpActionResult CreateCourseStatistics(string userLogin, int courseId)
        {
            try
            {
                statistics.CreateCourseStatistics(userLogin, courseId);
                return Ok();
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
                statistics.UpdateStatistics(statisticsDto);
                return Ok();
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
                statistics.DeleteStatistics(statisticsId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
