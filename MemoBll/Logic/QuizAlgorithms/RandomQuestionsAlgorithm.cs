using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL.Entities;

namespace MemoBll.Logic.QuizAlgorithms
{
    class RandomQuestionsAlgorithm : IAlgorithm
    {
        private static Random random;

        public IEnumerable<Card> GetCardsForQuiz(
            int numberOfCards,
            IEnumerable<Statistics> currentStatistics)
        {
            List<Card> result = new List<Card>();
            if (currentStatistics != null)
            {
                if (numberOfCards < currentStatistics.Count())
                {
                    return
                     currentStatistics
                     .Select(statistics => statistics.Card)
                     .OrderBy(card => Guid.NewGuid())
                     .Take(numberOfCards);
                }
                else
                {
                    currentStatistics.ToList().ForEach(stat => {
                        result.Add(stat.Card);
                    });
                    return result;
                }
            }
            return result;
        }
    }
}
