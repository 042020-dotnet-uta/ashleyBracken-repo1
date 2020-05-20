﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SleepingSelkieBusinessLogic.BusinessModels
{
    /// <summary>
    /// Products Business Model
    /// </summary>
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
    }
}
