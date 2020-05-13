using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieDataAccess.Repositories
{
    class OrdersRepository : IOrdersRepository
    {
        public Task<IEnumerable<Orders>> GetOrdersByCustomer(string customerID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Orders>> GetOrdersByStore(int storeID)
        {
            throw new NotImplementedException();
        }
    }
}
