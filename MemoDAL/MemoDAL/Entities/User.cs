using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDAL.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Comments = new List<Comment>();
            Reports = new List<Report>();
        }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}