﻿using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
	public class QuizBll
    {
        IQuiz quiz;
        IConverterToDTO converterToDto;

        public QuizBll()
        {
            this.quiz = new Quiz(new UnitOfWork(new MemoContext()));
            this.converterToDto = new ConverterToDTO();
        }

        public QuizBll(IQuiz quiz, IConverterToDTO converterToDto)
        {
            this.quiz = quiz;
            this.converterToDto = converterToDto;
        }

        public bool CheckAnswer (AnswerDTO answerDto, int cardId)
        {
            throw new NotImplementedException();
        }

        public List<AnswerDTO> GetAllAnswersInCard(int cardId)
        {
            var answers = quiz.GetAllAnswersInCard(cardId).ToList();

            return answers != null 
                ? converterToDto.ConvertToAnswerListDTO(answers) 
                : throw new ArgumentNullException();
        }
        
        public List<CardDTO> GetCardsByDeck(string deckName)   
         {
             List<Card> cards = quiz.GetCardsByDeck(deckName).ToList();
             
             return cards != null
                ? converterToDto.ConvertToCardListDTO(cards)
                : throw new ArgumentNullException();
         }
        public bool IsAnswerCorrect(int cardId, string answerText)
        {
            return quiz.IsAnswerCorrect(cardId, answerText);
        }
    }
}
