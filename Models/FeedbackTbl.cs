using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class FeedbackTbl
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Feedback { get; set; }
        public DateTime Createddate { get; set; }

        public virtual UserTbl User { get; set; }
    }
}
