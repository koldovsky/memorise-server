using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{

    public class Statistic: BaseEntity

    {
        public int SuccessPercent { get; set; }
        public User User { get; set; }
        public Deck Deck { get; set; }
    }
}