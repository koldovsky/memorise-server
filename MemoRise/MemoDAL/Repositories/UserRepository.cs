using MemoDAL.Entities;
using MemoDAL.EF;


namespace MemoDAL.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository(MemoContext context):base(context)
        {

        }
    }
}