using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PlayerWebApp.EU.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage="Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

      //  public bool IsAdmin { get; set; }

    }
}