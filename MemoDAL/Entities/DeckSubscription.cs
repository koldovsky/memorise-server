using System.ComponentModel.DataAnnotations.Schema;

namespace MemoDAL.Entities
{
    public class DeckSubscription: BaseEntity
    {
        public int Rating { get; set; }

        [ForeignKey(nameof(User))]
        [Index("IX_UserId_DeckId", 1, IsUnique = true)]
        public string UserId { get; set; }

        [ForeignKey(nameof(Deck))]
        [Index("IX_UserId_DeckId", 2, IsUnique = true)]
        public int DeckId { get; set; }

        public virtual User User { get; set; }
        public virtual Deck Deck { get; set; }
    }
}
