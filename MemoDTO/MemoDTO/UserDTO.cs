using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Comments = new List<CommentDTO>();
            Reports = new List<ReportDTO>();
        }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }
        public virtual ICollection<ReportDTO> Reports { get; set; }
    }
}