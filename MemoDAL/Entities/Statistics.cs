namespace MemoDAL.Entities
{
    public class Statistics: BaseEntity
    {
        public int CardStatus { get; set; }
        public virtual User User { get; set; }
        public virtual Card Card { get; set; }
    }
}