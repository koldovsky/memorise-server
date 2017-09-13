using System.Collections.Generic;

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