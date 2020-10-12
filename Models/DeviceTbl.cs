using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class DeviceTbl
    {
        public DeviceTbl()
        {
            DevicepermId = new HashSet<DevicepermId>();
            RegistereddevicesTbl = new HashSet<RegistereddevicesTbl>();
        }

        public int DeviceId { get; set; }
        public int DevicecatId { get; set; }
        public string Devicename { get; set; }
        public string Description { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Updateddate { get; set; }

        public virtual DevicecategoryTbl Devicecat { get; set; }
        public virtual ICollection<DevicepermId> DevicepermId { get; set; }
        public virtual ICollection<RegistereddevicesTbl> RegistereddevicesTbl { get; set; }
    }
}
