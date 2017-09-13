using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>
    {
        public UserRoleRepository(MemoContext context):base(context)
        {

        }
    }
}