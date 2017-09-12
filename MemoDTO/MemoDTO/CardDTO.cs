using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class CardDTO
    {
        public CardDTO()
        {
            Comments = new List<CommentDTO>();
            Answers = new List<AnswerDTO>();
        }
        public string Question { get; set; }

        
        public virtual string CardType { get; set; }
        public virtual int DeckId { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<AnswerDTO> Answers { get; set; }

    }
}