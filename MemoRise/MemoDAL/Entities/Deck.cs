﻿using System.Collections.Generic;

namespace MemoDAL.Entities
{
    public class Deck: BaseEntity
    {
        public Deck()
        {
            Cards = new List<Card>();
            Courses = new List<Course>();
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Photo { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}