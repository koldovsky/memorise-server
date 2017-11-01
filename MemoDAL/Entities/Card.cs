using System.Collections.Generic;

namespace MemoDAL.Entities
{
    public class Card : BaseEntity
    {
        public Card()
        {
            this.Comments = new List<Comment>();
            this.Answers = new List<Answer>();
        }

        public string Question { get; set; }

        public virtual CardType CardType { get; set; }

        public virtual Deck Deck { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}