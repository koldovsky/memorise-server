using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class CardDTO:BaseEntity
    {
        public CardDTO()
        {
            
            Answers = new List<AnswerDTO>();
        }
        public string Question { get; set; }

        
        public virtual CardTypeDTO CardType { get; set; }
        public virtual DeckDTO Deck { get; set; }
       
        public virtual ICollection<AnswerDTO> Answers { get; set; }

    }
}