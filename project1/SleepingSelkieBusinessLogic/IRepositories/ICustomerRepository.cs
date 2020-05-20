using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieBusinessLogic.IRepositories
{
    /// <summary>
    /// customer repository which acts as an intermediary between the business model and data models
    /// </summary>
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByName(string fName,string lName);
        Task AddCustomerAsync(Customer customer);
    }
}
