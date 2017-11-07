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
            List<Statistics> currentStatisticsList = currentStatistics.ToList();
            List<Card> result = new List<Card>();

            if (numberOfCards < currentStatistics.Count())
            {
                random = new Random();

                int r = random.Next(currentStatistics.Count());

                int[] indexes = Enumerable.Range(0, currentStatistics.Count()-1).ToArray();

                for (int i = 0; i < numberOfCards; i++)
                {
                    int j = random.Next(i, currentStatistics.Count()-1);

                    int temp = indexes[i];
                    indexes[i] = indexes[j];
                    indexes[j] = temp;

                    result.Add(currentStatisticsList[indexes[i]].Card);
                }

                return result;
            }
            else
            {
                currentStatisticsList.ForEach(x => result.Add(x.Card));
                return result;
            }

        }
    }
}
