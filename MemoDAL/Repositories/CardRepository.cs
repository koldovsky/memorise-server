using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(MemoContext context) : base(context)
        {
        }
    }
}