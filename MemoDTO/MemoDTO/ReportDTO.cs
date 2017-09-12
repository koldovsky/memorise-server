using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoDTO
{
    public class ReportDTO:BaseEntity
    {
        
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual UserDTO Sender { get; set; }
    }
}