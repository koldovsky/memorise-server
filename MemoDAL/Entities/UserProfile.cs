using System.Collections.Generic;

namespace MemoDAL.Entities
{
	public class UserProfile : BaseEntity
    {
        public UserProfile()
        {
            Comments = new List<Comment>();
            Reports = new List<Report>();
        }
        public bool IsBlocked { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}