using System;
using System.Collections.Generic;

namespace IoTHUB_v1._0.Models
{
    public partial class ContactformTbl
    {
        public int CtId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime Createddate { get; set; }
    }
}
