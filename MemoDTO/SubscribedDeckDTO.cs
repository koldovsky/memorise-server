namespace MemoDTO
{
    public class SubscribedDeckDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public UserDTO User { get; set; }
        public DeckDTO Deck { get; set; }
    }
}
