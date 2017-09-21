using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class DeckRepository : BaseRepository<Deck>, IDeckRepository
    {
        public DeckRepository(MemoContext context) : base(context) { }
        
        public IEnumerable<Deck> GetSomeAmount(int previousNumbersOfDecks, int numbersOfDecksOnPage)
        {
            return MemoContext.Decks.OrderBy(deck => deck.Id)
                .Skip(previousNumbersOfDecks).Take(numbersOfDecksOnPage).ToList();
        }
    }
}