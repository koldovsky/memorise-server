using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IQuiz
    {
        bool CheckAnswer(Answer answer, int cardId);
        IEnumerable<Answer> GetAllAnswersInCard(int cardId);
        IEnumerable<Card> GetCardsByDeck(string deckName);
    }
}
