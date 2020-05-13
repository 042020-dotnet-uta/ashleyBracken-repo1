using System;
using System.Collections.Generic;
using System.Text;

namespace SleepingSelkieBusinessLogic.BusinessModels
{
   public  class Inventory
    {
        public int InventoryID { get; set; }
        public Store Store { get; set; }

        public Products Products { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
    }
}
