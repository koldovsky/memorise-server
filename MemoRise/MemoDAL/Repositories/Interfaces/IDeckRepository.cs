using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoDAL.Repositories.Interfaces
{
    interface IDeckRepository: IRepository<Deck>
    {
        IEnumerable<Deck> GetSomeAmount(int previousNumbersOfDecks, int numbersOfDecksOnPage);
    }
}
