using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(MemoContext context) : base(context)
        { }
    }
}
