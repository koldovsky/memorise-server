using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class RoleRepository: BaseRepository<Role>
    {
        public RoleRepository(MemoContext context):base(context)
        {

        }
    }
}