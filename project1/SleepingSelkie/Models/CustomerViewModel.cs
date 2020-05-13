using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace SleepingSelkie.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter a phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter a valid 10 digit phone mumber")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Password : Must be 8+ characters")]
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Please enter a valid password with 8 or more characters")]
        public string Password { get; set; }
        
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Your password and confirm password need to match")]
        public string ConfirmPassword { get; set; }
      //  public string PreferredStore { get; set; }
    }
}
