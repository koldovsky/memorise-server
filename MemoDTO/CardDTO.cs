﻿using System.Collections.Generic;

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

        public string Question { get; set; }

        public string CardTypeName { get; set; }

        public string DeckName { get; set; }

        public virtual CardTypeDTO CardType { get; set; }

        public virtual DeckDTO Deck { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }

        public virtual ICollection<AnswerDTO> Answers { get; set; }
    }
}