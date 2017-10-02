using MemoDAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MemoDAL.Repositories
{
	public class RoleRepository : RoleManager<Role>
    {
        public RoleRepository(RoleStore<Role> store)
                    : base(store)
        { }
    }
}