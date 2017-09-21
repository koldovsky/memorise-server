namespace MemoDAL.Entities
{
    public class Statistics: BaseEntity

    {
        public int SuccessPercent { get; set; }
        public User User { get; set; }
        public Deck Deck { get; set; }
    }
}