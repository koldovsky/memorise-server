using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class CardTypeRepository : BaseRepository<CardType>
    {
        public CardTypeRepository(MemoContext context):base(context)
        {

        }
    }
}