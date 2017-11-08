using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL.Entities;

namespace MemoBll.Logic.QuizAlgorithms
{
    class RandomAlgorithm : IAlgorithm
    {
        
        public IEnumerable<Card> GetCardsForQuiz(
            int numberOfCards,
            IEnumerable<Statistics> currentStatistics)
        {
            numberOfCards = 5; //for test

            List<Card> result = new List<Card>();
            if (currentStatistics != null)
            {
               
                    result.AddRange(
                      currentStatistics
                     .Select(statistics => statistics.Card)
                     .OrderBy(card => Guid.NewGuid())
                     .Take(numberOfCards));
               
            }
            return result;
        }

        public IEnumerable<Card> GetCardsForRepeat(IEnumerable<Statistics> statistics)
        {
            //throw new NotImplementedException();
            return new List<Card>();
        }
    }
}
