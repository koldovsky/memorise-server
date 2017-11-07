using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoBll.Interfaces
{
	public interface IQuiz
    {
        IEnumerable<Answer> GetAllAnswersInCard(int cardId);

        IEnumerable<Card> GetCardsByDeck(string deckName);

        IEnumerable<Card> GetCardsByDeckArray(string[] deckName);

        bool IsAnswerCorrect(int cardId, string answerText);

        IEnumerable<Card> GetCardsByCourse(string courseName);

        IEnumerable<Card> GetCardsForSubscription(
            int numberOfCards,
            IEnumerable<Statistics> statistics);

        //IEnumerable<Card> GetCardsForRepeat(string userLogin);
    }
}
