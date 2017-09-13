using System.Collections.Generic;

namespace MemoDAL.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
           Coments = new List<Comment>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Photo { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Coments { get; set; }
    }
}