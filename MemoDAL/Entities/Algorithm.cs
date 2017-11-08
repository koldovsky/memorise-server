namespace MemoDAL.Entities
{
    public class Algorithm : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ClassName { get; set; }

        public bool IsActive { get; set; }
    }
}
