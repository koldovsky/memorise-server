using System;
using System.Web.Http;
using MemoDAL.Entities;
using MemoBll.Managers;
using MemoDTO;

namespace MemoRise.Controllers
{
    public class StatisticsController : ApiController
    {
        CustomerStatisticsBll statistics = new CustomerStatisticsBll();

        [HttpGet]
        [Route("Statistics/GetStatistics/{userId}/{cardId}/{answerText}")]
        public IHttpActionResult GetStatistics(string userId, int cardId)
        {
            try
            {
                var statisticsList = statistics.GetStatistics(userId, cardId);
                return Ok(statisticsList);
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
        public IHttpActionResult SaveStatistics(StatisticsDTO statisticsDto)
        {
            try
            {
                statistics.SaveStatistics(statisticsDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}