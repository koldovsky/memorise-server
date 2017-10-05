namespace MemoDTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual CourseDTO Course { get; set; }
    }
}