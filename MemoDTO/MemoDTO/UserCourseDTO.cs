using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class UserCourseDTO:BaseEntity
    {
        public int Rating { get; set; }
        public UserDTO User { get; set; }
        public CourseDTO Course { get; set; }
    }
}