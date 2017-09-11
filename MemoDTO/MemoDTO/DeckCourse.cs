using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class DeckCourse:BaseEntity
    {
        public Deck Deck { get; set; }
        public Course Course { get; set; } 
    }
}