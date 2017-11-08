using MemoDAL;
using MemoDAL.Entities;
using System;
using System.Collections.Generic;

namespace MemoBll.Logic.QuizAlgorithms
{
    public class QuizLogic
    {
        private IAlgorithm algorithm;

        
        public QuizLogic(IUnitOfWork unitOfWork)
        {
            string className = unitOfWork.Algorithms.GetAll().FirstOrDefault(alg => alg.IsActive == true).ClassName;
            SetAlgorithm(className);
        }

        public void SetAlgorithm(string className)
        {
            Type type = Type.GetType($"MemoBll.Logic.QuizAlgorithms.{className}");
            this.algorithm = Activator.CreateInstance(type) as IAlgorithm;
        }

        public IEnumerable<Card> GetCards(int numberOfCards,
            IEnumerable<Statistics> statistics)
        {
            return this.algorithm.GetCardsForQuiz(numberOfCards,statistics); 
        }

        public IEnumerable<Card> GetAllCardsForRepeat (IEnumerable<Statistics> statistics)
        {
            return this.algorithm.GetCardsForRepeat(statistics);
        }
    }
}
