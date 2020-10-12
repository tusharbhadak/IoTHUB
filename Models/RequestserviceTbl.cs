using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTHUB_v1._0.Models
{
    public partial class RequestserviceTbl
    {
        public int RequestId { get; set; }
       
        [Required]
        [Display(Name = "UserName")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "ServiceName")]
        public int ServiceId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Createddate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Requestdescription { get; set; }

        public virtual ServiceTbl Service { get; set; }
        public virtual UserTbl User { get; set; }
    }
}
