using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using System.Linq;

namespace SleepingSelkieDataAccess.Repositories
{
  public  class CustomerRepository : ICustomerRepository
    {
        private readonly SelkieContext dbContext;

        public CustomerRepository(SelkieContext selkieContext)
        {
            dbContext = selkieContext;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            var custStore = dbContext.Stores
           .Where(c => c.StoreName == customer.StoreName).FirstOrDefault();
            var cust = new DataModels.Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Store = custStore,
                CustomerID = customer.PhoneNumber,   
            };

            if (await dbContext.Customers.AnyAsync(c => c.FirstName == cust.FirstName && c.LastName == cust.LastName))
            {
                throw new InvalidOperationException("Customer Already exists");
            }
            dbContext.Add(cust);
            await dbContext.SaveChangesAsync();
            
        }

        public Task<Customer> GetCustomerByName(string fName, string lName)
        {
            throw new NotImplementedException();
        }
    }
}
