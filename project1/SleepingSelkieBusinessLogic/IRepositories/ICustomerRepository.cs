using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieBusinessLogic.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByName(string fName,string lName);
        Task AddCustomerAsync(Customer customer);
    }
}
