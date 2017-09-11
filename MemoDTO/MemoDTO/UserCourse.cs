using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class UserCourse:BaseEntity
    {
        public int Rating { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }
    }
}