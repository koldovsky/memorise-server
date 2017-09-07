using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class UserController : ApiController
    {
        private UserBll userbll = new UserBll();

        public IEnumerable<User> GetAllUsers()
        {
            return userbll.GetUsers();
        }

        public User GetUser(int id)
        {
            return userbll.GetUser(id);
        }

        public void PostUser(User item)
        {
            userbll.AddUser(item);
        }

        public bool PutUser(User item)
        {
            return userbll.UpdateUser(item);
        }

        public void DeleteUser(int id)
        {
            userbll.RemoveUser(id);
        }
    }
}
