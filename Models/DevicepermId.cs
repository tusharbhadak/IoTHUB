using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class DevicepermId
    {
        public int DevicepermId1 { get; set; }
        public int UserId { get; set; }
        public int DeviceId { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Updateddate { get; set; }

        public virtual DeviceTbl Device { get; set; }
        public virtual UserTbl User { get; set; }
    }
}
