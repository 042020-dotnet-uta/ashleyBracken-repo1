using System;

namespace SleepingSelkieBusinessLogic.BusinessModels
{
    public class Orders
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public int ManaPotionsBought { get; set; }
        public int HealthPotionsBought { get; set; }
        public int StaminaPotionsBought { get; set; }
        private DateTime date;
        public DateTime Date { get => date; set => date = value; }
    }
}
