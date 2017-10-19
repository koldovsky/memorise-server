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
        [Route("Statistics/GetStatistics/{userName}/{cardId}")]
        public IHttpActionResult GetStatistics(string userName, int cardId)
        {
            try
            {
                var statisticsList = statistics.GetStatistics(userName, cardId);
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
        [Route("Statistics/GetDeckStatistics/{userName}/{deckId}")]
        public IHttpActionResult GetDeckStatistics(string userName, int deckId)
        {
            try
            {
                var statisticsList = statistics
                    .GetDeckStatistics(userName, deckId);
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
        [Route("Statistics/GetCourseStatistics/{userName}/{courseId}")]
        public IHttpActionResult GetCourseStatistics(string userName, int courseId)
        {
            try
            {
                var statisticsList = statistics.GetCourseStatistics(userName, courseId);
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
        [Route("Statistics/CreateDeckStatistics/{userName}/{deckId}")]
        public IHttpActionResult CreateDeckStatistics(string userName, int deckId)
        {
            try
            {
                statistics.CreateDeckStatistics(userName, deckId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Statistics/CreateCourseStatistics/{userName}/{courseId}")]
        public IHttpActionResult CreateCourseStatistics(string userName, int courseId)
        {
            try
            {
                statistics.CreateCourseStatistics(userName, courseId);
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
