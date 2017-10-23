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
        IConverterToDto converterToDto;

        public QuizBll()
        {
            this.quiz = new Quiz(new UnitOfWork(new MemoContext()));
            this.converterToDto = new ConverterToDto();
        }

        public QuizBll(IQuiz quiz, IConverterToDto converterToDto)
        {
            this.quiz = quiz;
            this.converterToDto = converterToDto;
        }

        public List<AnswerDTO> GetAllAnswersInCard(int cardId)
        {
            var answers = quiz.GetAllAnswersInCard(cardId).ToList();

            return converterToDto.ConvertToAnswerListDto(answers);
        }
        
        public List<CardDTO> GetCardsByDeck(string deckLink)   
        {
             List<Card> cards = quiz.GetCardsByDeck(deckLink).ToList();
             
             return converterToDto.ConvertToCardListDto(cards);
        }

        public List<CardDTO> GetCardsByDeckArray(string[] deckLink)   
        {
            List<Card> cards = quiz.GetCardsByDeckArray(deckLink).ToList();

            return converterToDto.ConvertToCardListDto(cards);
        }

        public List<CardDTO> GetCardsByCourse(string courseLink)
        {
            List<Card> cards = quiz.GetCardsByCourse(courseLink).ToList();

            return converterToDto.ConvertToCardListDto(cards);
        }

        public bool IsAnswerCorrect(int cardId, string answerText)
        {
            return quiz.IsAnswerCorrect(cardId, answerText);
        }
    }
}
