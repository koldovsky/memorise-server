using MemoDAL.EF;
using MemoDAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDAL.Repositories
{
   public class UserRepository: UserManager<User>
    {
        public UserRepository (IUserStore<User> store)
                : base(store)
        {
        }
        
    }
    
}
