using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDAL.Entities
{
    public class CardType: BaseEntity
    {
        public CardType()
        {
            Cards = new List<Card>();
        }
        public string Name { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}