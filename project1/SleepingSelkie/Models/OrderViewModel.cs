using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SleepingSelkie.Models
{
    /// <summary>
    /// Order View Model to store info to be passed into the views
    /// </summary>
    public class OrderViewModel
    {
        [Display(Name = "Customer Phone Number")]
        public string CustomerPhoneNumber { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name ="Store Name")]
        public string StoreName { get; set; }
        [Display(Name = "Mana Potions")]
        public int ManaPotionsBought { get; set; }
        [Display(Name ="Health Potions")]
        public int HealthPotionsBought { get; set; }
        [Display(Name ="Stamina Potions")]
        public int StaminaPotionsBought { get; set; }
        [Display(Name ="Magic Wands")]
        public int MagicWandsBought { get; set; }
        [Display(Name ="Cleric Talismans")]
        public int ClericsTalismanBought { get; set; }
        [Display(Name ="Date")]
        public DateTime Date { get; set; }
    }
}
