using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTHUB_v1._0.Models
{
    public partial class RoleTbl
    {
        public RoleTbl()
        {
            UserTbl = new HashSet<UserTbl>();
        }

        public int RoleId { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string Rolename { get; set; }

        public virtual ICollection<UserTbl> UserTbl { get; set; }
    }
}
