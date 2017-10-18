using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class DeckDTO
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
        [StringLength(ValidationItems.MAX_LENGTH_TEXTAREA,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "TOO_LONG_AREA")]
        [RegularExpression(ValidationItems.INPUT_REGEX,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "INCORRECT_INPUT")]
        public string Description { get; set; }

        [RegularExpression(ValidationItems.ONLY_NUMBERS,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "ONLY_NUMBERS")]
        public int Price { get; set; }

        public int CardsNumber { get; set; }

		public string Photo { get; set; }

        [Required]
        [StringLength(ValidationItems.MAX_LENGTH_INPUT,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "TOO_LONG")]
        [RegularExpression(ValidationItems.ONLY_ALPHANUMERIC,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = "ONLY_ALPHANUMERIC")]
        public string Linking { get; set; }

        [Required]
        [StringLength(ValidationItems.MAX_LENGTH_INPUT,
             ErrorMessageResourceType = typeof(Resources.ErrorMessages),
             ErrorMessageResourceName = "TOO_LONG")]
        [RegularExpression(ValidationItems.INPUT_REGEX,
             ErrorMessageResourceType = typeof(Resources.ErrorMessages),
             ErrorMessageResourceName = "INCORRECT_INPUT")]
        public string CategoryName { get; set; }

        public List<string> CardIds { get; set; }

        public List<string> CourseNames { get; set; }
    }
}