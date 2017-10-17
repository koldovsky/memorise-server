using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "maximum length 30 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "maximum length 30 characters")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", 
            ErrorMessage = "only alphanumeric are allowed")]
        public string Linking { get; set; }
    }
}