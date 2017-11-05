using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
    public class Quiz : IQuiz
    {
        private const int CORRECT = 1;
        private const int INCORRECT = -1;
        private const int NOANSWER = 0;
        private IUnitOfWork unitOfWork;

        public Quiz()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public Quiz(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Answer> GetAllAnswersInCard(int cardId)
        {
            return unitOfWork.Cards.Get(cardId)?.Answers 
                ?? throw new ArgumentNullException();
        }

        public IEnumerable<Card> GetCardsByCourse(string courseLink)
        {
            var result = new List<Card>();
            var decks = unitOfWork.Courses
                .GetAll().FirstOrDefault(x => x.Linking == courseLink)?.Decks
                ?? throw new ArgumentNullException();
            foreach (var deck in decks)
            {
                result.AddRange(deck.Cards);
            }

            return result;
        }

        #region QuizLogic

        public IEnumerable<Card> GetCardsForSubscription(
            int numberOfCards,
            IEnumerable<Statistics> statistics)
        {
            var cardsForQuiz = new List<Card>();
            int numberOfCardsLeft;

            // someMethod to check and add cards from repeat if need
            // cardsForQuiz.addRange(someMethod);

            if (cardsForQuiz.Count == numberOfCards)
            {
                return cardsForQuiz;
            }

            numberOfCardsLeft = numberOfCards - cardsForQuiz.Count();

            if (numberOfCardsLeft == numberOfCards)
            {
                if (numberOfCards % 2 == 0)
                {
                    cardsForQuiz.AddRange(GetCardsWithInCorrectPriority(cardsForQuiz, numberOfCards / 2, statistics));
                }
                else
                {
                    cardsForQuiz.AddRange(GetCardsWithInCorrectPriority(cardsForQuiz, (numberOfCards / 2) + 1, statistics));
                }

                cardsForQuiz.AddRange(GetCardsWithNoAnswerPriority(cardsForQuiz, numberOfCards / 2, statistics));
            }
            else 
            {
                cardsForQuiz.AddRange(GetCardsWithInCorrectPriority(cardsForQuiz, numberOfCardsLeft, statistics));
            }
            
            return cardsForQuiz;
        }

        public IEnumerable<Card> GetCardsWithInCorrectPriority(
            List<Card> cardsForQuiz,
            int numberOfCards, 
            IEnumerable<Statistics> currentStatistics)
        {

            var cards = new List<Card>();
            int numberOfCardsLeft = numberOfCards;

            for (int cardStatus = INCORRECT; cardStatus <= CORRECT; cardStatus++)
            {
                cards.AddRange(
                    GetCardsWithSomeStatus(
                    cardsForQuiz,
                    numberOfCardsLeft,
                    currentStatistics,
                    cardStatus));

                numberOfCardsLeft = numberOfCards - cards.Count();

                if (numberOfCardsLeft == 0)
                {
                    return cards;
                }
            }

            return cards;
        }

        public IEnumerable<Card> GetCardsWithNoAnswerPriority(
            List<Card> cardsForQuiz,
            int numberOfCards, 
            IEnumerable<Statistics> currentStatistics)
        {
            var cards = new List<Card>();
            int numberOfCardsLeft = numberOfCards;

            cards.AddRange(
               GetCardsWithSomeStatus(
               cardsForQuiz,
               numberOfCardsLeft,
               currentStatistics,
               NOANSWER));

            if (cards.Count == numberOfCards)
            {
                return cards;
            }

            numberOfCardsLeft = numberOfCards - cards.Count();

            cards.AddRange(
            GetCardsWithSomeStatus(
               cardsForQuiz,
               numberOfCardsLeft,
               currentStatistics,
               INCORRECT));

            if (cards.Count == numberOfCards)
            {
                return cards;
            }

            numberOfCardsLeft = numberOfCards - cards.Count();

            cards.AddRange(
                GetCardsWithSomeStatus(
                cardsForQuiz,
                numberOfCardsLeft, 
                currentStatistics, 
                CORRECT));

            return cards;
        }

        public IEnumerable<Card> GetCardsWithSomeStatus(
            List<Card> cardsForQuiz,
            int numberOfCards,
            IEnumerable<Statistics> currentStatistics, 
            int cardStatus)
        {
           return
                currentStatistics
                .Where(statistics => statistics.CardStatus == cardStatus
                && !cardsForQuiz.Select(c => c.Id).Contains(statistics.Card.Id))
                .Select(statistics => statistics.Card)
                .OrderBy(card => Guid.NewGuid())
                .Take(numberOfCards);
        }
       
        #endregion

        public IEnumerable<Card> GetCardsByDeck(string deckLink)
        {
            return unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Linking == deckLink)?.Cards
                ?? throw new ArgumentNullException();
        }

        public IEnumerable<Card> GetCardsByDeckArray(string[] deckLink)
        {
            var carsByDecks = unitOfWork.Decks  
                .GetAll().Where(x => deckLink.Contains(x.Linking)).Select(temp => temp.Cards);
            List<Card> listCards = new List<Card>();   
            foreach (var item in carsByDecks)
            {
                foreach (var temp in item)
                {
                    listCards.Add(temp);
                }
            }

            return listCards;
        }

        public IEnumerable<Card> GetCardsByDeckAndAmount(string deckName, int amount)
        {
            var cards = unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Name == deckName)?.Cards
                ?? throw new ArgumentNullException();
            return cards;
        }

        public bool IsAnswerCorrect(int cardId, string answerText)
        {
            Card card = unitOfWork.Cards.GetAll().FirstOrDefault(x => x.Id == cardId);
            if (card != null)
            {
                foreach (Answer answer in card.Answers)
                {
                    if (answer.Text.ToLower() == answerText.ToLower())
                    {
                        return answer.IsCorrect;
                    }
                }

                return false;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
