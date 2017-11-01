using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MemoDAL.Repositories
{
    public class DeckRepository : BaseRepository<Deck>, IDeckRepository
    {
        public DeckRepository(MemoContext context) : base(context) { }

        public IEnumerable<Deck> GetSomeAmount(int previousNumbersOfDecks,
                                               int numbersOfDecksOnPage)
        {
            return MemoContext.Decks
                .OrderBy(deck => deck.Id)
                .Skip(previousNumbersOfDecks)
                .Take(numbersOfDecksOnPage)
                .ToList();
        }
    }
}