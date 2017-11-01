using MemoDAL.Entities;
using Microsoft.AspNet.Identity;

namespace MemoDAL.Repositories
{
    public class UserRepository : UserManager<User>
    {
        private IUserStore<User> store;

        public UserRepository(IUserStore<User> store)
                : base(store)
        {
            this.store = store;
        }
    }
}