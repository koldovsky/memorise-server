using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationItems.MAX_LENGTH_TEXTAREA,
           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = "TOO_LONG_AREA")]
        [RegularExpression(ValidationItems.INPUT_REGEX,
           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = "INCORRECT_INPUT")]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }        
    }
}
