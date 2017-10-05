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

        public IEnumerable<Card> GetCardsByDeck(string deckName)
        {
            return unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Name == deckName)?.Cards;
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
