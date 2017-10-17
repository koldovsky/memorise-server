using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class DeckDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "maximum length 30 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "maximum length 250 characters")]
        public string Description { get; set; }
        [RegularExpression(@"^[0-9]+$",
           ErrorMessage = "only numeric are allowed")]
        public int Price { get; set; }
        public int CardsNumber { get; set; }
		public string Photo { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "maximum length 30 characters")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "only alphanumeric are allowed")]
        public string Linking { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "maximum length 30 characters")]
        public string CategoryName { get; set; }
        public List<string> CardIds { get; set; }
        public List<string> CourseNames { get; set; }
    }
}