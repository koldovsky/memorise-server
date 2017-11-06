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
        private IQuiz quiz;
        private IConverterToDTO converterToDTO;

        public QuizBll()
        {
            this.quiz = new Quiz(new UnitOfWork(new MemoContext()));
            this.converterToDTO = new ConverterToDTO();
        }

        public QuizBll(IQuiz quiz, IConverterToDTO converterToDTO)
        {
            this.quiz = quiz;
            this.converterToDTO = converterToDTO;
        }

        public List<AnswerDTO> GetAllAnswersInCard(int cardId)
        {
            var answers = quiz.GetAllAnswersInCard(cardId).ToList();

            return converterToDTO.ConvertToAnswerListDTO(answers);
        }
        
        public List<CardDTO> GetCardsByDeck(string deckLink)   
        {
             List<Card> cards = quiz.GetCardsByDeck(deckLink).ToList();
             
             return converterToDTO.ConvertToCardListDTO(cards);
        }

        public List<CardDTO> GetCardsByDeckArray(string[] deckLink)   
        {
            List<Card> cards = quiz.GetCardsByDeckArray(deckLink).ToList();

            return converterToDTO.ConvertToCardListDTO(cards);
        }

        public List<CardDTO> GetCardsByCourse(string courseLink)
        {
            List<Card> cards = quiz.GetCardsByCourse(courseLink).ToList();

            return converterToDTO.ConvertToCardListDTO(cards);
        }

        public List<CardDTO> GetCardsForSubscription(
            int numberOfCards,
            IEnumerable<Statistics> statistics)
        {
            List<Card> cards = quiz
                .GetCardsForSubscription(numberOfCards, statistics)
                .ToList();

            return converterToDTO.ConvertToCardListDTO(cards);
        }

        public List<CardDTO> GetCardsForRepeat(string userLogin)
        {
            return converterToDTO.ConvertToCardListDTO(quiz.GetCardsForRepeat(userLogin));
        }

        public bool IsAnswerCorrect(int cardId, string answerText)
        {
            return quiz.IsAnswerCorrect(cardId, answerText);
        }
    }
}
