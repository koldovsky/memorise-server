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

        private const int NOREPEAT = 0;
        private const int ONEREPEAT = 1;
        private const int TWOREPEAT = 2;
        private const int THREEREPEAT = 3;
        private const int TOURREPEAT = 4;

        private const int FirstRepeatInHours = 12;
        private const int SecondRepeatInHours = 48;
        private const int ThirdRepeatInHours = 24 * 6;
        private const int FourthRepeatInHours = 24 * 20;

        private const int FirstDeadlineForRepeatInHours = 24;
        private const int SecondDeadlineForRepeatInHours = 72;
        private const int ThirdDeadlineForRepeatInHours = 24 * 8;
        private const int FourthDeadlineForRepeatInHours = 24 * 24;

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

            IEnumerable<Card> cardsToRepeat = GetCartsForRepeat(statistics);

            if (cardsToRepeat.Count() > 0)
            {
                cardsForQuiz.AddRange(cardsToRepeat);
            }

            if (cardsForQuiz.Count == numberOfCards)
            {
                return cardsForQuiz;
            }

            numberOfCardsLeft = numberOfCards - cardsForQuiz.Count();

            if (numberOfCardsLeft == numberOfCards)
            {
                if (numberOfCards % 2 == 0)
                {
                    cardsForQuiz.AddRange(GetCardsWithInCorrectPriority(numberOfCards / 2, statistics));
                }
                else
                {
                    cardsForQuiz.AddRange(GetCardsWithInCorrectPriority((numberOfCards / 2) + 1, statistics));
                }

                cardsForQuiz.AddRange(GetCardsWithNoAnswerPriority(numberOfCards / 2, statistics));
            }
            else 
            {
                cardsForQuiz.AddRange(GetCardsWithInCorrectPriority(numberOfCardsLeft, statistics));
            }
            
            return cardsForQuiz;
        }

        public IEnumerable<Card> GetCardsWithInCorrectPriority(
            int numberOfCards, 
            IEnumerable<Statistics> currentStatistics)
        {
            var cardsForQuiz = new List<Card>();

            int numberOfCardsLeft = numberOfCards;

            for (int cardStatus = INCORRECT; cardStatus <= CORRECT; cardStatus++)
            {
                cardsForQuiz.AddRange(GetCardsWithSomeStatus(
                    numberOfCardsLeft,
                    currentStatistics,
                    cardStatus));

                numberOfCardsLeft = numberOfCards - cardsForQuiz.Count();

                if (numberOfCardsLeft == 0)
                {
                    return cardsForQuiz;
                }
            }

            return cardsForQuiz;
        }

        public IEnumerable<Card> GetCardsWithNoAnswerPriority(
            int numberOfCards, 
            IEnumerable<Statistics> currentStatistics)
        {
            var cardsForQuiz = new List<Card>();

            int numberOfCardsLeft = numberOfCards;

            cardsForQuiz.AddRange(
                GetCardsWithSomeStatus(
                    numberOfCardsLeft,
                currentStatistics, 
                NOANSWER));
            
            if (cardsForQuiz.Count == numberOfCards)
            {
                return cardsForQuiz;
            }

            numberOfCardsLeft = numberOfCards - cardsForQuiz.Count();

            cardsForQuiz.AddRange(
                GetCardsWithSomeStatus(
                    numberOfCardsLeft,
                currentStatistics, 
                INCORRECT));

            if (cardsForQuiz.Count == numberOfCards)
            {
                return cardsForQuiz;
            }

            numberOfCardsLeft = numberOfCards - cardsForQuiz.Count();

            cardsForQuiz.AddRange(
                GetCardsWithSomeStatus(
                    numberOfCardsLeft,
                currentStatistics, 
                CORRECT));

            return cardsForQuiz;
        }

        public void SetCardStatusToNoAnswerIfLateness(IEnumerable<Statistics> statistics)
        {
            if(statistics != null)
            {
                statistics.ToList().ForEach(stat =>
                {
                    if (stat.CardStatus == CORRECT)
                    {
                        int passedHours = (DateTime.Now - stat.DateOfPassingQuiz).Hours;

                        if (stat.counter == NOREPEAT && passedHours > FirstDeadlineForRepeatInHours ||
                        stat.counter == ONEREPEAT && passedHours > SecondDeadlineForRepeatInHours ||
                        stat.counter == TWOREPEAT && passedHours > ThirdDeadlineForRepeatInHours ||
                        stat.counter == THREEREPEAT && passedHours > FourthDeadlineForRepeatInHours
                        )
                        {
                            stat.CardStatus = 0;
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Returns cards with status you sent. If there will not be cards with 
        /// this status, IEnumerable will be empty
        /// </summary>
        /// <param name="numberOfCards">if you pass null it means get all cards</param>
        /// <param name="currentStatistics">entries IEnumerable of statistics</param>
        /// <param name="cardStatus">CORRECT = 1, INCORRECT = -1, NOANSWER = 0</param>
        /// <returns>IEnumerable of cards with status cardStatus</returns>
        public IEnumerable<Card> GetCardsWithSomeStatus(
            int? numberOfCards,
            IEnumerable<Statistics> currentStatistics, 
            int cardStatus)
        {
            int cardsNumber = numberOfCards ?? -1;
            if(cardsNumber == -1)
            {
                return currentStatistics
                .Where(statistics => statistics.CardStatus == cardStatus)
                .Select(statistics => statistics.Card)
                .OrderBy(card => Guid.NewGuid());
            }
            return currentStatistics
                .Where(statistics => statistics.CardStatus == cardStatus)
                .Select(statistics => statistics.Card)
                .OrderBy(card => Guid.NewGuid())
                .Take(cardsNumber);
        }

        private IEnumerable<Card> GetCartsForRepeat(IEnumerable<Statistics> statistics)
        {
            List<Card> result = new List<Card>();
            if (statistics != null)
            {
                SetCardStatusToNoAnswerIfLateness(statistics);
                statistics.ToList().ForEach(stat =>
                {
                    if (stat.CardStatus == CORRECT)
                    {
                        int passedHours = (DateTime.Now - stat.DateOfPassingQuiz).Hours;

                        if (stat.counter == NOREPEAT && passedHours > FirstRepeatInHours ||
                        stat.counter == ONEREPEAT && passedHours > SecondRepeatInHours ||
                        stat.counter == TWOREPEAT && passedHours > ThirdRepeatInHours ||
                        stat.counter == THREEREPEAT && passedHours > FourthRepeatInHours
                        )
                        {
                            result.Add(stat.Card);
                        }
                    }
                });
            }
            return result;
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
