using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class UserRole
    {
        public UserDTO User { get; set; }
        public RoleDTO Role { get; set; }
    }
}