using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL.Entities;

namespace MemoBll.Logic.QuizAlgorithms
{
    class DefaultAlgorithm : IAlgorithm
    {
        private const int CORRECT = 1;
        private const int INCORRECT = -1;
        private const int NOANSWER = 0;

        private const int ONECORRECT = 1;
        private const int TWOCORRECT = 2;
        private const int THREECORRECT = 3;
        private const int FOURCORRECT = 4;

        private const int FirstRepeatInHours = 12;
        private const int SecondRepeatInHours = 48;
        private const int ThirdRepeatInHours = 24 * 6;
        private const int FourthRepeatInHours = 24 * 20;

        private const int FirstDeadlineForRepeatInHours = 24;
        private const int SecondDeadlineForRepeatInHours = 72;
        private const int ThirdDeadlineForRepeatInHours = 24 * 8;
        private const int FourthDeadlineForRepeatInHours = 24 * 24;

        public IEnumerable<Card> GetCardsForQuiz(int numberOfCards,
           IEnumerable<Statistics> statistics)
        {
            var cardsForQuiz = new List<Card>();
            int numberOfCardsLeft;

            IEnumerable<Card> cardsToRepeat = GetCardsForRepeat(statistics);

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

        public IEnumerable<Card> GetCardsForRepeat(IEnumerable<Statistics> statistics)
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

                        if (stat.NumbersOfSequentialCorrectAnswers == ONECORRECT && passedHours > FirstRepeatInHours ||
                        stat.NumbersOfSequentialCorrectAnswers == TWOCORRECT && passedHours > SecondRepeatInHours ||
                        stat.NumbersOfSequentialCorrectAnswers == THREECORRECT && passedHours > ThirdRepeatInHours ||
                        stat.NumbersOfSequentialCorrectAnswers == FOURCORRECT && passedHours > FourthRepeatInHours
                        )
                        {
                            result.Add(stat.Card);
                        }
                    }
                });
            }
            return result;
        }

        private IEnumerable<Card> GetCardsWithInCorrectPriority(
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

        private IEnumerable<Card> GetCardsWithNoAnswerPriority(
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

        private void SetCardStatusToNoAnswerIfLateness(IEnumerable<Statistics> statistics)
        {
            if (statistics != null)
            {
                statistics.ToList().ForEach(stat =>
                {
                    if (stat.CardStatus == CORRECT)
                    {
                        int passedHours = (DateTime.Now - stat.DateOfPassingQuiz).Hours;

                        if (stat.NumbersOfSequentialCorrectAnswers == ONECORRECT && passedHours > FirstDeadlineForRepeatInHours ||
                        stat.NumbersOfSequentialCorrectAnswers == TWOCORRECT && passedHours > SecondDeadlineForRepeatInHours ||
                        stat.NumbersOfSequentialCorrectAnswers == THREECORRECT && passedHours > ThirdDeadlineForRepeatInHours ||
                        stat.NumbersOfSequentialCorrectAnswers == FOURCORRECT && passedHours > FourthDeadlineForRepeatInHours
                        )
                        {
                            stat.CardStatus = 0;
                            stat.NumbersOfSequentialCorrectAnswers = 0;
                        }
                    }
                });
            }
        }

        private IEnumerable<Card> GetCardsWithSomeStatus(
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
    }
}
