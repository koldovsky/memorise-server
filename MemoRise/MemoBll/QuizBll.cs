using System.Collections.Generic;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    class QuizBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public bool CheckAnswer (AnswerDTO answer, int cardId)  
        {
            Card card = unitOfWork.Cards.GetOneElementOrDefault(x => x.Id == cardId);
            foreach (Answer answers in card.Answers)    
            {
                if (converterToDto.ConvertToAnswerDTO(answers) == answer) 
                {
                    return answer.IsCorrect;
                }
            }
            return false;
        }

        public List<AnswerDTO> GetAllAnswersInCard(int cardId)
        {
            List<AnswerDTO> answers = new List<AnswerDTO>();
            Card card = unitOfWork.Cards.GetOneElementOrDefault(x => x.Id == cardId);
            foreach (Answer answer in card.Answers)
            {
                answers.Add(converterToDto.ConvertToAnswerDTO(answer));
            }
            return answers;
        }
        

         public List<CardDTO> GetCardsByDeck(string deckName)   
         {
             List<CardDTO> cards = new List<CardDTO>();
             Deck deck = unitOfWork.Decks.GetOneElementOrDefault(x => x.Name == deckName);
             foreach (Card card in deck.Cards)   
             {
                 cards.Add(converterToDto.ConvertToCardDTO(card));
             }
             return cards;
         }
    }
}
