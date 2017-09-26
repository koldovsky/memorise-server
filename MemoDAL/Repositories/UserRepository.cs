using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;


namespace MemoDAL.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(MemoContext context) : base(context) { }
    }
}