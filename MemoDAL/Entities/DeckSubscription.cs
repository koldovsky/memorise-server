namespace MemoDAL.Entities
{
    public class DeckSubscription: BaseEntity
    {
        public int Rating { get; set; }
        public virtual User User { get; set; }
        public virtual Deck Deck { get; set; }
    }
}
