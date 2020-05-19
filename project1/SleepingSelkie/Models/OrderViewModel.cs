﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SleepingSelkie.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public String CustomeNamer { get; set; }
        public string StoreName { get; set; }
        public int ManaPotionsBought { get; set; }
        public int HealthPotionsBought { get; set; }
        public int StaminaPotionsBought { get; set; }
        public int MagicWandsBought { get; set; }
        public int ClericsTalismanBought { get; set; }
        public DateTime Date { get; set; }
    }
}