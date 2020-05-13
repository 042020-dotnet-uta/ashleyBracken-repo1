using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;

namespace SleepingSelkieDataAccess.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        public Task AddCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByName(string fName, string lName)
        {
            throw new NotImplementedException();
        }
    }
}
