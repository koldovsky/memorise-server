using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationItems.MAX_LENGTH_INPUT,
           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = "TOO_LONG")]
        [RegularExpression(ValidationItems.INPUT_REGEX,

           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = "INCORRECT_INPUT")]
        public string Name { get; set; }

        [Required]
        [StringLength(ValidationItems.MAX_LENGTH_INPUT,
           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = "TOO_LONG")]
        [RegularExpression(ValidationItems.ONLY_ALPHANUMERIC,
           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = "ONLY_ALPHANUMERIC")]
        public string Linking { get; set; }

        public string[] CourseNames { get; set; }

        public string[] DeckNames { get; set; }
    }
}