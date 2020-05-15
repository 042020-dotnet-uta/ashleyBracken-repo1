using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SleepingSelkieDataAccess.DataModels
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public Store Store { get; set; }
        public Products Products { get; set; }
        public int ProductQuantity { get; set; }
    }
}
