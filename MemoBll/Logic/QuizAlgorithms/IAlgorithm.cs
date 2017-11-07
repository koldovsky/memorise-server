using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBll.Logic.QuizAlgorithms
{
    public interface IAlgorithm
    {
        IEnumerable<Card> GetCardsForQuiz(int numberOfCards,
            IEnumerable<Statistics> statistics);

        IEnumerable<Card> GetCardsForRepeat(IEnumerable<Statistics> statistics);
    }
}
