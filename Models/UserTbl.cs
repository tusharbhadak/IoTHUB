using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTHUB_v1._0.Models
{
    public partial class UserTbl
    {
        public UserTbl()
        {
            DevicepermId = new HashSet<DevicepermId>();
            FeedbackTbl = new HashSet<FeedbackTbl>();
            HelpSupportTbl = new HashSet<HelpSupportTbl>();
            RegistereddevicesTbl = new HashSet<RegistereddevicesTbl>();
            RequestserviceTbl = new HashSet<RequestserviceTbl>();
            RfidTbl = new HashSet<RfidTbl>();
        }

        public int UserId { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[Display(Name = "Confirm Password")]
        //[DataType(DataType.Password), Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }

        //[Display(Name = "New Password")]
        //[DataType(DataType.Password)]
        //public string NewPassword { get; set; }

        //[Display(Name = "New Confirm Password")]
        //[DataType(DataType.Password)]
        //public string ConfirmNewPassword { get; set; }



        [Required]
        [Display(Name = "Mobile No")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string Companyname { get; set; }

        [Required]
        [Display(Name = "Company Email")]
        public string Companyemail { get; set; }

        [Display(Name = "Is Active")]
        public bool Isactive { get; set; }

        [Display(Name = "Is Parent")]
        public bool Isparent { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
      
        [Display(Name = "Parent Id")]
        public int? ParentId { get; set; }

        [Required]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Createddate { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        public string Mediapath { get; set; }

        public virtual RoleTbl Role { get; set; }
        public virtual ServiceTbl Service { get; set; }
        public virtual ICollection<DevicepermId> DevicepermId { get; set; }
        public virtual ICollection<FeedbackTbl> FeedbackTbl { get; set; }
        public virtual ICollection<HelpSupportTbl> HelpSupportTbl { get; set; }
        public virtual ICollection<RegistereddevicesTbl> RegistereddevicesTbl { get; set; }
        public virtual ICollection<RequestserviceTbl> RequestserviceTbl { get; set; }
        public virtual ICollection<RfidTbl> RfidTbl { get; set; }
    }
}
