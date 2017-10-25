using System.ComponentModel.DataAnnotations.Schema;

namespace MemoDAL.Entities
{
    public class Statistics: BaseEntity
    {
        public int CardStatus { get; set; }

        [ForeignKey(nameof(User))]
        [Index("IX_UserId_CardId", 1, IsUnique = true)]
        public string UserId { get; set; }

        [ForeignKey(nameof(Card))]
        [Index("IX_UserId_CardId", 2, IsUnique = true)]
        public int CardId { get; set; }

        public virtual User User { get; set; }
        public virtual Card Card { get; set; }
    }
}