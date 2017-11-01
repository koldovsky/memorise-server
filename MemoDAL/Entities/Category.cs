using System.Collections.Generic;

namespace MemoDAL.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Courses = new List<Course>();
            this.Decks = new List<Deck>();
        }

        public string Name { get; set; }

        public string Linking { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Deck> Decks { get; set; }
    }
}