using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Logic.QuizAlgorithms
{
    public interface IAlgorithm
    {
        IEnumerable<Card> GetCardsForQuiz(int numberOfCards,
            IEnumerable<Statistics> statistics);

        IEnumerable<Card> GetCardsForRepeat(IEnumerable<Statistics> statistics);
    }
}
