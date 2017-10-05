using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IQuiz
    {
        IEnumerable<Answer> GetAllAnswersInCard(int cardId);
        IEnumerable<Card> GetCardsByDeck(string deckName);
        bool IsAnswerCorrect(int cardId, string answerText);
    }
}
