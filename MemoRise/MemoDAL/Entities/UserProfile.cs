using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDAL.Entities
{
    public class UserProfile: BaseEntity
    {
        public UserProfile()  
        {
            Comments = new List<Comment>();
            Reports = new List<Report>();
        }
        public bool IsBlocked { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
