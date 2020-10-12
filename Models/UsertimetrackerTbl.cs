using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class UsertimetrackerTbl
    {
        public int UttId { get; set; }
        public int RfidId { get; set; }
        public int Workinghours { get; set; }
        public DateTime Date { get; set; }

        public virtual RfidTbl Rfid { get; set; }
    }
}
