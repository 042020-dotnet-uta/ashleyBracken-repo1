using System;

namespace SleepingSelkieBusinessLogic.BusinessModels
{
    public class Orders
    {
        public string CustomerID { get; set; }
        public string StoreName { get; set; }
        public int ManaPotionsBought { get; set; }
        public int HealthPotionsBought { get; set; }
        public int StaminaPotionsBought { get; set; }
        public int MagicWandsBought { get; set; }
        public int ClericsTalismanBought { get; set; }
        public DateTime Date { get; set; }
    }
}
