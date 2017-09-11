using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDAL.Entities
{
    public class Deck: BaseEntity
    {
        public Deck()
        {
            Cards = new List<Card>();
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Photo { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}