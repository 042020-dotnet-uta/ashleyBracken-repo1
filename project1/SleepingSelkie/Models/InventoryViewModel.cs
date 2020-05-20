using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SleepingSelkieBusinessLogic.BusinessModels;

namespace SleepingSelkie.Models
{
    public class InventoryViewModel  
    {
        [Display (Name ="Store")]
        public string StoreName { get; set;}

        [Display(Name ="Product")]
        public string ProductName { get; set; }

        [Display(Name ="Description")]
        public string ProductDescription { get; set; }
        
        [Display(Name ="Price")]
        public int Price { get; set; }

        [Display(Name ="Quantity In Stock")]
        public int Quantity { get; set;}

        [Display(Name = "Order Amount")]
        [Range(0,100,ErrorMessage ="Please Enter A valid amount")]
        public int OrderAmount { get; set; }
    }
}
