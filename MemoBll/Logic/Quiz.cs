﻿using MemoBll.Interfaces;
using MemoBll.Logic.QuizAlgorithms;
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
        private IUnitOfWork unitOfWork;
        private QuizLogic quizLogic;

        public Quiz()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
        }

        public Quiz(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.quizLogic = new QuizLogic(unitOfWork);
        }

        public IEnumerable<Answer> GetAllAnswersInCard(int cardId)
        {
            return unitOfWork.Cards.Get(cardId)?.Answers 
                ?? throw new ArgumentNullException();
        }

        public IEnumerable<Card> GetCardsByCourse(string courseLink)
        {
            var result = new List<Card>();
            var decks = unitOfWork.Courses
                .GetAll().FirstOrDefault(x => x.Linking == courseLink)?.Decks
                ?? throw new ArgumentNullException();
            foreach (var deck in decks)
            {
                result.AddRange(deck.Cards);
            }

            return result;
        }

        public IEnumerable<Card> GetCardsForSubscription(
            int numberOfCards,
            IEnumerable<Statistics> statistics)
        {
            return quizLogic.GetCards(numberOfCards, statistics);
        }

        public IEnumerable<Card> GetCardsForRepeat(IEnumerable<Statistics> statistics)
        {
            return quizLogic.GetAllCardsForRepeat(statistics);
        }

        public IEnumerable<Card> GetCardsByDeck(string deckLink)
        {
            return unitOfWork.Decks
                .GetAll().FirstOrDefault(x => x.Linking == deckLink)?.Cards
                ?? throw new ArgumentNullException();
        }
        
        public Algorithm GetAlgorithm(int id)
        {
            return unitOfWork.Algorithms
                .GetAll()
                .FirstOrDefault(x => x.Id == id);
        }

        public void UpdateAlgorithms(Algorithm algorithm)
        {
            var algorithms = unitOfWork.Algorithms.GetAll().ToList();

            foreach (var alg in algorithms)
            {
                alg.IsActive = false;
                UpdateAlgorithm(alg);
            }

            algorithm.IsActive = true;
            UpdateAlgorithm(algorithm);
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
                .GetAll().FirstOrDefault(x => x.Name == deckName)?.Cards
                ?? throw new ArgumentNullException();
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

        private void UpdateAlgorithm(Algorithm algorithm)
        {
            unitOfWork.Algorithms.Update(algorithm);
            unitOfWork.Save();
        }
    }
}
