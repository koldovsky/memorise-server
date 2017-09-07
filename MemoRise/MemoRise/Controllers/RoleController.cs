using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class RoleController : ApiController
    {
        private RoleBll rolebll = new RoleBll();

        public IEnumerable<Role> GetAllRoles()
        {
            return rolebll.GetAllRoles();
        }

        public Role GetRole(int id)
        {
            return rolebll.GetRole(id);
        }

        public void PostRole(Role item)
        {
            rolebll.AddRole(item);
        }

        public bool PutRole(Role item)
        {
            return rolebll.UpdateRole(item);
        }

        public void DeleteRole(int id)
        {
            rolebll.RemoveRole(id);
        }
    }
}
