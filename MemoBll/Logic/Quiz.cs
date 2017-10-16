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
        IUnitOfWork unitOfWork;

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
            return unitOfWork.Cards.Get(cardId)?.Answers ?? throw new ArgumentNullException();
        }

        public IEnumerable<Card> GetCardsByCourse(string courseLink)
        {
            var result = new List<Card>();
            var decks = unitOfWork.Courses
                .GetAll().FirstOrDefault(x => x.Linking == courseLink)?.Decks;
            foreach (var deck in decks)
            {
                result.AddRange(deck.Cards);
            }
            return result;
        }

        public IEnumerable<Card> GetCardsByDeck(string deckLink)
        {
            return unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Linking == deckLink)?.Cards;
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
                .GetAll().FirstOrDefault(x => x.Name == deckName)?.Cards;
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
