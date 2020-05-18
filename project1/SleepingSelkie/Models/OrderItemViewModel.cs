using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SleepingSelkie.Models
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; }

        [Display(Name ="Order Amount")]
        [Required]
        [Range(0,100,ErrorMessage ="Please try a different amount")]
        public int OrderAmount { get; set; }
    }
}
