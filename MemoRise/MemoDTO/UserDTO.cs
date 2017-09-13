using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
    }
}