using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class IdentityUpdateDTO
    {
        [Required]
        [StringLength(ValidationItems.MAX_LENGTH_INPUT,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "TOO_LONG")]
        public string ExistingLogin { get; set; }

        [Required]
        public UserDTO NewUserData { get; set; }
    }
}
