using System;

namespace MemoDAL.Entities
{
    public class Report : BaseEntity
    {
        public string Reason { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public virtual User Sender { get; set; }
    }
}