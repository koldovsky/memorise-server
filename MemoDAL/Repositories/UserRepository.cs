using MemoDAL.Entities;
using Microsoft.AspNet.Identity;


namespace MemoDAL.Repositories
{
	public class UserRepository : UserManager<User>
    {
        public UserRepository(IUserStore<User> store)
                : base(store)
        {
        }

    }

}