namespace MemoDAL.Entities
{

    public class Statistic: BaseEntity

    {
        public int SuccessPercent { get; set; }
        public User User { get; set; }
        public Deck Deck { get; set; }
    }
}