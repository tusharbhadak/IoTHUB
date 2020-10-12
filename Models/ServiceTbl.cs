using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTHUB_v1._0.Models
{
    public partial class ServiceTbl
    {
        public ServiceTbl()
        {
            RequestserviceTbl = new HashSet<RequestserviceTbl>();
            UserTbl = new HashSet<UserTbl>();
        }

        public int ServiceId { get; set; }
        [Required]
        [Display(Name = "Service Name")]
        public string Servicename { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Createddate { get; set; }

        public virtual ICollection<RequestserviceTbl> RequestserviceTbl { get; set; }
        public virtual ICollection<UserTbl> UserTbl { get; set; }
    }
}
