using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SleepingSelkie.Models
{
    public class OrderViewModel
    {
        public string CustomerPhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string StoreName { get; set; }
        public int ManaPotionsBought { get; set; }
        public int HealthPotionsBought { get; set; }
        public int StaminaPotionsBought { get; set; }
        public int MagicWandsBought { get; set; }
        public int ClericsTalismanBought { get; set; }
        public DateTime Date { get; set; }
    }
}
