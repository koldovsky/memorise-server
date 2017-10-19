namespace MemoDAL.Entities
{
    public class SubscribedCourse: BaseEntity
    {
        public int Rating { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}