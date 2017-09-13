using System;

namespace MemoDTO
{
    public class ReportDTO
    {
        
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual UserDTO Sender { get; set; }
    }
}