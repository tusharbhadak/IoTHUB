using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTHUB_v1._0.Models
{
    public partial class RfidTbl
    {
        public RfidTbl()
        {
            UserattendanceTbl = new HashSet<UserattendanceTbl>();
            UsertimetrackerTbl = new HashSet<UsertimetrackerTbl>();
        }

        public int RfidId { get; set; }
        
        [Required]
        [Display(Name ="UserName")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "RFID")]
        public int? Rfid { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Createddate { get; set; }
        public bool Isactive { get; set; }

        public virtual UserTbl User { get; set; }
        public virtual ICollection<UserattendanceTbl> UserattendanceTbl { get; set; }
        public virtual ICollection<UsertimetrackerTbl> UsertimetrackerTbl { get; set; }
    }
}
