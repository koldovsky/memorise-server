using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{

    public class StatisticDTO: BaseEntity

    {
        public int SuccessPercent { get; set; }
        public UserDTO User { get; set; }
        public DeckDTO Deck { get; set; }
    }
}