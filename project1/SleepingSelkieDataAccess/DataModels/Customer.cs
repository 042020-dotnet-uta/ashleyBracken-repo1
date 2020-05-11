using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SleepingSelkieDataAccess.DataModels
{
    class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        private string firstName;
        public string FirstName { get => firstName; set => firstName = value; }
        private string lastName;
        public string LastName { get => lastName; set => lastName = value; }
        public Store Store { get; set; }
        public int StoreID { get; set; }
    }
}
