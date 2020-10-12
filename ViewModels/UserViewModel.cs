using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoTHUB_v1._0.ViewModels
{
    public class UserViewModel
    {
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


        [Required]
        [Display(Name = "Mobile No")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        //[Required]
        [Display(Name = "Company Name")]
        public string Companyname { get; set; }

        //[Required]
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
        public int ParentId { get; set; }

        [Required]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Createddate { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
