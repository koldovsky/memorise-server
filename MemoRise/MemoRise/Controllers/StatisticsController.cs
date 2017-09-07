using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class StatisticsController : ApiController
    {
        private StatisticsBll statisticsbll = new StatisticsBll();

        public IEnumerable<Statistics> GetAllStatistics(int userId)
        {
            return statisticsbll.GetAlluserId(userId);
        }

        public Statistics GetStatistics(int StatisticsId)
        {
            return statisticsbll.Statistics(StatisticsId);
        }

        public void PostStatisticsId(Statistics item)
        {
            statisticsbll.AddStatistics(item);
        }

        public bool PutCaregory(Statistics item)
        {
            return statisticsbll.UpdateStatisticsId(item);
        }

        public void DeleteStatistics(int StatisticsId)
        {
            statisticsbll.RemoveStatistics(StatisticsId);
        }
    }
}
