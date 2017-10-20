namespace MemoDTO
{
    public class DeckSubscriptionDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public UserDTO User { get; set; }
        public DeckDTO Deck { get; set; }
    }
}
