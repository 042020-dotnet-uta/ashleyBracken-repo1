using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SleepingSelkieDataAccess.DataModels
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        public string StoreName { get; set; }
    }
}
