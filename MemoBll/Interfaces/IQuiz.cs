using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL.Entities;
using MemoDTO;

namespace MemoBll.Interfaces
{
    public interface IQuiz
    {
        bool CheckAnswer(Answer answer, int cardId);
        IEnumerable<Answer> GetAllAnswersInCard(int cardId);
        IEnumerable<Card> GetCardsByDeck(string deckName);
    }
}
