namespace MemoDAL.Entities
{
    public class DeckCourse:BaseEntity
    {
        public Deck Deck { get; set; }
        public Course Course { get; set; } 
    }
}