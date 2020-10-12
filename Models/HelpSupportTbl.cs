using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class HelpSupportTbl
    {
        public int HelpId { get; set; }
        public int UserId { get; set; }
        public int ComptypeId { get; set; }
        public DateTime Createddate { get; set; }

        public virtual ComplaintypeTbl Comptype { get; set; }
        public virtual UserTbl User { get; set; }
    }
}
