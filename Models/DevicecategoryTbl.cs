using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class DevicecategoryTbl
    {
        public DevicecategoryTbl()
        {
            DeviceTbl = new HashSet<DeviceTbl>();
        }

        public int DevicecatId { get; set; }
        public string Devicecatname { get; set; }
        public DateTime Createddate { get; set; }

        public virtual ICollection<DeviceTbl> DeviceTbl { get; set; }
    }
}
