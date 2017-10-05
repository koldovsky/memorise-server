using MemoBll.Interfaces;
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

        public List<AnswerDTO> GetAllAnswersInCard(int cardId)
        {
            var answers = quiz.GetAllAnswersInCard(cardId).ToList();

            return converterToDto.ConvertToAnswerListDTO(answers);
        }
        
        public List<CardDTO> GetCardsByDeck(string deckLink)   
        {
             List<Card> cards = quiz.GetCardsByDeck(deckLink).ToList();
             
             return converterToDto.ConvertToCardListDTO(cards);
        }

        public List<CardDTO> GetCardsByCourse(string courseLink)
        {
            List<Card> cards = quiz.GetCardsByCourse(courseLink).ToList();

            return converterToDto.ConvertToCardListDTO(cards);
        }

        public bool IsAnswerCorrect(int cardId, string answerText)
        {
            return quiz.IsAnswerCorrect(cardId, answerText);
        }
    }
}
