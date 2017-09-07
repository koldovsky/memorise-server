using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class DeckController : ApiController
    {
        private DeckBll deckBll = new DeckBll();

        public IEnumerable<Deck> GetAllDecks()
        {
            return deckBll.GetAllDecks();
        }

        public Deck GetDeck(int id)
        {
            return deckBll.GetDeck(id);
        }

        public void PostDeck(Deck item)
        {
            deckBll.AddDeck(item);
        }

        public bool PutDeck(Deck item)
        {
            return deckBll.UpdateDeck(item);
        }

        public void DeleteDeck(int id)
        {
            deckBll.RemoveDeck(id);
        }
    }
}
