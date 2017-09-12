using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class DeckDTO: BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}