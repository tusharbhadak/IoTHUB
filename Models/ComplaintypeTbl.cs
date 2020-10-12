using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class ComplaintypeTbl
    {
        public ComplaintypeTbl()
        {
            HelpSupportTbl = new HashSet<HelpSupportTbl>();
        }

        public int ComptypeId { get; set; }
        public string CompType { get; set; }
        public DateTime Createddate { get; set; }

        public virtual ICollection<HelpSupportTbl> HelpSupportTbl { get; set; }
    }
}
