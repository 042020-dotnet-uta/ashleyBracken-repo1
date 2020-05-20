using System;
using System.Collections.Generic;
using System.Text;

namespace SleepingSelkieBusinessLogic.BusinessModels
{/// <summary>
/// Customer Business Model
/// </summary>
   public class Customer
    {
        public string PhoneNumber { get; set; }
        private string firstName;
        public string FirstName { get => firstName; set => firstName = value; }
        private string lastName;
        public string LastName { get => lastName; set => lastName = value; }
        public Store Store { get; set; }
        public string StoreName { get; set; }
    }
}
