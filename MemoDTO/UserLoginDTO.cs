using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class UserLoginDTO
    {
        [Required]
        [StringLength(ValidationItems.MAX_LENGTH_INPUT,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "TOO_LONG")]
        public string Login { get; set; }

        [StringLength(ValidationItems.MAX_LENGTH_INPUT,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "TOO_LONG")]
        public string Password { get; set; }

        [RegularExpression(ValidationItems.EMAIL_PATTERN,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "PATTERN_NOT_VALID")]
        public string Email { get; set; }
    }
}
