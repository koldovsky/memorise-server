using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class AnswerController : ApiController
    {
        private AnswerBll answerbll = new AnswerBll();

        public IEnumerable<Answer> GetAllAnswers()
        {
            return answerbll.GetAllAnswers();
        }

        public Answer GetAnswer(int id)
        {
            return answerbll.GetAnswer(id);
        }

        public void PostAnswer(Answer item)
        {
            answerbll.AddAnswer(item);
        }

        public bool PutCaregory(Answer item)
        {
            return answerbll.UpdateAnswer(item);
        }

        public void DeleteAnswer(int id)
        {
            answerbll.RemoveAnswer(id);
        }
    }
}
