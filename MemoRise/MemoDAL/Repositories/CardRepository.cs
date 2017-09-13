using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class CardRepository : BaseRepository<Card>
    {
        public CardRepository(MemoContext context):base(context)
        {

        }
    }
}