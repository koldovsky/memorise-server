using System.Collections.Generic;

namespace MemoDAL.Entities
{
    public class Role:BaseEntity
    {
        public Role()
        {
            Users = new List<User>();
        }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}