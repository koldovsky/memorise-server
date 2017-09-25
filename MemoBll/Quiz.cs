using System;
using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;

namespace MemoBll
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

        public bool CheckAnswer(Answer answer, int cardId)
        {
            //bool result = false;
            //Card card = unitOfWork.Cards.Get(cardId);

            //foreach (Answer answers in card.Answers)
            //{
            //    if (answers.Text == answer.Text)
            //    {
            //        result = true;
            //        break;
            //    }
            //}

            //return result;
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAllAnswersInCard(int cardId)
        {
            return unitOfWork.Cards.Get(cardId)?.Answers;
        }

        public IEnumerable<Card> GetCardsByDeck(string deckName)
        {
            return unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Name == deckName)?.Cards;
        }
    }
}
