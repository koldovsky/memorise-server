using System.Collections.Generic;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;
using System.Linq;

namespace MemoBll
{
    class QuizBll
    {
        IUnitOfWork unitOfWork;
        IConverterToDTO converterToDto;

        public QuizBll()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
            this.converterToDto = new ConverterToDTO();
        }

        public QuizBll(IUnitOfWork unitOfWork, IConverterToDTO converterToDto)
        {
            this.unitOfWork = unitOfWork;
            this.converterToDto = converterToDto;
        }

        public bool CheckAnswer (AnswerDTO answer, int cardId)
        {
            bool result = false;
            Card card = unitOfWork.Cards
                .GetAll().FirstOrDefault(x => x.Id == cardId);

            foreach (Answer answers in card.Answers)    
            {
                if (converterToDto.ConvertToAnswerDTO(answers).Text == answer.Text) 
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public List<AnswerDTO> GetAllAnswersInCard(int cardId)
        {
            List<AnswerDTO> answers = new List<AnswerDTO>();
            Card card = unitOfWork.Cards
                .GetAll().FirstOrDefault(x => x.Id == cardId);
            foreach (Answer answer in card.Answers)
            {
                answers.Add(converterToDto.ConvertToAnswerDTO(answer));
            }

            return answers;
        }
        
        public List<CardDTO> GetCardsByDeck(string deckName)   
         {
             List<CardDTO> cards = new List<CardDTO>();
             Deck deck = unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Name == deckName);
             foreach (Card card in deck.Cards)   
             {
                 cards.Add(converterToDto.ConvertToCardDTO(card));
             }

             return cards;
         }
    }
}
