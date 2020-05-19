﻿using System;

namespace SleepingSelkieBusinessLogic.BusinessModels
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string Customer { get; set; }
        public string Store { get; set; }
        public int ManaPotionsBought { get; set; }
        public int HealthPotionsBought { get; set; }
        public int StaminaPotionsBought { get; set; }
        public int MagicWandsBought { get; set; }
        public int ClericsTalismanBought { get; set; }
        public DateTime Date { get; set; }
    }
}
