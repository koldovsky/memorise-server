﻿using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBll.Logic.QuizAlgorithms
{
    public class QuizLogic
    {
        private IAlgorithm algorithm = new DefaultAlgorithm();

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
