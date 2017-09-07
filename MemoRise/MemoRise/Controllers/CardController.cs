using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class CardController : ApiController
    {
        private CardBll cardBll = new CardBll();

        public IEnumerable<Card> GetAllCards()
        {
            return cardBll.GetAllCards();
        }

        public Card GetCard(int id)
        {
            return cardBll.GetCard(id);
        }

        public void PostCard(Card item)
        {
            cardBll.AddCard(item);
        }

        public bool PutCard(Card item)
        {
            return cardBll.UpdateCard(item);
        }

        public void DeleteCard(int id)
        {
            cardBll.RemoveCard(id);
        }
    }
}
