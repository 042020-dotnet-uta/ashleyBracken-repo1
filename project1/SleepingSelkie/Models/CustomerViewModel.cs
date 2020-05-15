using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using SleepingSelkieBusinessLogic.BusinessModels;

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

        [Display(Name = "Choose Prefered store")]
        public StoreName storeName { get; set; }
    }
    public enum StoreName
    {
        SleepingSelkiePrimaryLocation,
        SleepingSelkieSecondaryLocation,
        SleepingSelkieLocation3
    }

}
