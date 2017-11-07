using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBll.Logic.QuizAlgorithms
{
    public class QuizLogic
    {
        private IAlgorithm algorithm;

        public void SetAlgorithm(string className)
        {
            Type type = Type.GetType($"MemoBll.Logic.QuizAlgorithms.{className}");
            this.algorithm = Activator.CreateInstance(type) as IAlgorithm;
        }

        public IEnumerable<Card> GetCards()
        {
            return this.algorithm.GetCardsForQuiz(); 
        }
    }
}
