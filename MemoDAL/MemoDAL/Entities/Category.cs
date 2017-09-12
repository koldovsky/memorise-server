using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDAL.Entities
{
    public class Category: BaseEntity
    {
        public Category()
        {
            Courses = new List<Course>();
            Decks = new List<Deck>();
        }
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<Deck> Decks { get; set; }

        //public virtual ICollection<Course> Courses { get; set; }
        //public virtual ICollection<Deck> Decks { get; set; }
    }
}