using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoDAL.Repositories.Interfaces
{
    public interface IDeckRepository: IRepository<Deck>
    {
        IEnumerable<Deck> GetSomeAmount(int previousNumbersOfDecks, int numbersOfDecksOnPage);
    }
}
