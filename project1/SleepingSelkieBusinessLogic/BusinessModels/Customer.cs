using System;
using System.Collections.Generic;
using System.Text;

namespace SleepingSelkieBusinessLogic.BusinessModels
{
   public class Customer
    {
        public string CustomerID { get; set; }
        private string firstName;
        public string FirstName { get => firstName; set => firstName = value; }
        private string lastName;
        public string LastName { get => lastName; set => lastName = value; }
        public Store Store { get; set; }
    }
}
