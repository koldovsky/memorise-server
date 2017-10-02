using MemoDAL.EF;
using MemoDAL.Entities;

namespace MemoDAL.Repositories
{
	public class UserProfileRepository : BaseRepository<UserProfile>
    {
        public UserProfileRepository(MemoContext context) : base(context)
        {

        }
    }
}
