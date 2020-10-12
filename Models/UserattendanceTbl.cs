using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class UserattendanceTbl
    {
        public int AttendanceId { get; set; }
        public int RfidId { get; set; }
        public DateTime Attendancedate { get; set; }

        public virtual RfidTbl Rfid { get; set; }
    }
}
