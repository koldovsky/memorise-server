using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class CardTypeDTO: BaseEntity
    {
        public CardTypeDTO()
        {
            Cards = new List<CardDTO>();
        }
        public string Name { get; set; }

        public virtual ICollection<CardDTO> Cards { get; set; }
    }
}