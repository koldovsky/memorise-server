using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class DeckSubscriptionsRepository: BaseRepository<DeckSubscription>, IDeckSubscriptionRepository
    {
        public DeckSubscriptionsRepository(MemoContext context) : base(context) { }
    }
}
