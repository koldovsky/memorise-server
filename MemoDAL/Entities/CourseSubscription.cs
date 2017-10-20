namespace MemoDAL.Entities
{
    public class CourseSubscription: BaseEntity
    {
        public int Rating { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}