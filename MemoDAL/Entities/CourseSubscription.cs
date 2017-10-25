using System.ComponentModel.DataAnnotations.Schema;

namespace MemoDAL.Entities
{
    public class CourseSubscription : BaseEntity
    {
        public int Rating { get; set; }

        [ForeignKey(nameof(User))]
        [Index("IX_UserId_CourseId", 1, IsUnique = true)]
        public string UserId { get; set; }

        [ForeignKey(nameof(Course))]
        [Index("IX_UserId_CourseId", 2, IsUnique = true)]
        public int CourseId { get; set; }

        public virtual User User { get; set; }

        public virtual Course Course { get; set; }
    }
}