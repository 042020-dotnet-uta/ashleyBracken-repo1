using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SleepingSelkieDataAccess.DataModels
{
  public  class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public int ManaPotionsBought { get; set; }
        public int HealthPotionsBought { get; set; }
        public int StaminaPotionsBought { get; set; }
        public int MagicWandsBought { get; set; }
        public int ClericsTalismanBought { get; set; }
        public DateTime Date { get; set; }
    }
}
