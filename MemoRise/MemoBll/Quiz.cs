﻿using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    class Quiz
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public bool CheckAnswer (AnswerDTO answer, int cardId)  
        {
            Card card = unitOfWork.Cards.GetAll().FirstOrDefault(x => x.Id == cardId);
            foreach (Answer answers in card.Answers)    
            {
                if (converterToDto.ConvertToAnswerDTO(answers) == answer) 
                {
                    return answer.IsCorrect;
                }
            }
            return false;
        }

        // I don't know if this is method is correct?
        public List<AnswerDTO> GetAllAnswersInCard(int cardId)
        {
            List<AnswerDTO> answers = new List<AnswerDTO>();
            Card card = unitOfWork.Cards.GetAll().FirstOrDefault(x => x.Id == cardId);
            foreach (Answer answer in card.Answers)
            {
                answers.Add(converterToDto.ConvertToAnswerDTO(answer));
            }
            return answers;
        }
        

         public List<CardDTO> GetCardsByDeck(string deckName)   
         {
             List<CardDTO> cards = new List<CardDTO>();
             Deck deck = unitOfWork.Decks.GetAll().FirstOrDefault(x => x.Name == deckName);
             foreach (Card card in deck.Cards)   
             {
                 cards.Add(converterToDto.ConvertToCardDTO(card));
             }
             return cards;
         }
    }
}