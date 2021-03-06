﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SleepingSelkie.Models
{/// <summary>
/// Login View Model to pass info to the view
/// </summary>
    public class LoginViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
    }
}
