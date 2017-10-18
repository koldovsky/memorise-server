using MemoDAL.Entities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace MemoDAL.Repositories
{
	public class UserRepository : UserManager<User>
    {
        IUserStore<User> store;

        public UserRepository(IUserStore<User> store)
                : base(store)
        {
            this.store = store;
        }
            
        
        public IEnumerable<User> GetAll()
        {
            return this.GetAll();
        
        }

    }

}