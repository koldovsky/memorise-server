using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class SubscribedDeckRepository: BaseRepository<SubscribedDeck>, ISubscribedDeckRepository
    {
        public SubscribedDeckRepository(MemoContext context) : base(context) { }
    }
}
