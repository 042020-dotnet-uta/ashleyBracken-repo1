using System;
using System.Collections.Generic;
using System.Text;

namespace SleepingSelkieBusinessLogic.BusinessModels
{
   public  class Inventory
    {
        public int InventoryID { get; set; }
        public Store Store { get; set; }
        public string StoreName { get; set; }

        public Products Products { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
