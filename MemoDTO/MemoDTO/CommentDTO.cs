using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class CommentDTO
    {
        public string Message { get; set; }

        public virtual UserDTO User { get; set; }
        public virtual CourseDTO Course { get; set; }
    }
}