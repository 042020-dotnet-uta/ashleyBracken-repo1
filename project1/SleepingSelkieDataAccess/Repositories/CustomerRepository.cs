using Microsoft.EntityFrameworkCore;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using SleepingSelkieDataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieDataAccess.Repositories
{
  public  class CustomerRepository : ICustomerRepository
    {
        private readonly SelkieContext dbContext;

        public CustomerRepository(SelkieContext selkieContext)
        {
            dbContext = selkieContext;
        }
        public async Task AddCustomerAsync(SleepingSelkieBusinessLogic.BusinessModels.Customer customer)
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

        public async Task<SleepingSelkieBusinessLogic.BusinessModels.Customer> GetCustomerByName(string fName, string lName)
        {
            var cust = await dbContext.Customers.Include(s=>s.Store)
           .Where(s => s.FirstName == fName && s.LastName == lName).FirstOrDefaultAsync();

                return new SleepingSelkieBusinessLogic.BusinessModels.Customer
                {
                    FirstName = cust.FirstName,
                    LastName = cust.LastName,
                    PhoneNumber = cust.CustomerID,
                    StoreName = cust.Store.StoreName,
                };
        }
    }
}
