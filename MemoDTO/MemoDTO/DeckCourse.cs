using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class DeckCourse:BaseEntity
    {
        public DeckDTO Deck { get; set; }
        public CourseDTO Course { get; set; } 
    }
}