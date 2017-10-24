using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MemoDTO
{
    public class CardDTO
    {
        public CardDTO()
        {
            Comments = new List<CommentDTO>();
            Answers = new List<AnswerDTO>();
        }
        public int Id { get; set; }

        //[Required]
        //[StringLength(ValidationItems.MAX_LENGTH_TEXTAREA,
        //   ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //   ErrorMessageResourceName = "TOO_LONG_AREA")]
        //[RegularExpression(ValidationItems.INPUT_REGEX,
        //   ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //   ErrorMessageResourceName = "INCORRECT_INPUT")]
        public string Question { get; set; }

        public string CardTypeName { get; set; }
        public string DeckName { get; set; }

        public virtual CardTypeDTO CardType { get; set; }
        public virtual DeckDTO Deck { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<AnswerDTO> Answers { get; set; }
    }
}