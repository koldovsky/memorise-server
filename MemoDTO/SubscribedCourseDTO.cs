namespace MemoDTO
{
    public class SubscribedCourseDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public UserDTO User { get; set; }
        public CourseDTO Course { get; set; }
    }
}