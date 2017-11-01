using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class CardTypeRepository : BaseRepository<CardType>, ICardTypeRepository
    {
        public CardTypeRepository(MemoContext context) : base(context)
        {
        }
    }
}