using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;


namespace SleepingSelkieDataAccess.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly SelkieContext dbContext;

        public OrdersRepository(SelkieContext selkieContext)
        {
            dbContext = selkieContext;
        }
        public async Task AddOrdersAsync(SleepingSelkieBusinessLogic.BusinessModels.Orders order)
        {

            var newOrder = new DataModels.Orders
            {
                Customer = dbContext.Customers
                .Where(x => x.CustomerID == order.CustomerID).FirstOrDefault(),
                Store = dbContext.Stores
                .Where(x => x.StoreName == order.StoreName).FirstOrDefault(),
                ManaPotionsBought = order.ManaPotionsBought,
                StaminaPotionsBought = order.StaminaPotionsBought,
                HealthPotionsBought = order.HealthPotionsBought,
                ClericsTalismanBought = order.ClericsTalismanBought,
                MagicWandsBought = order.MagicWandsBought,
                Date = order.Date,
            };
            dbContext.Add(newOrder);
            await dbContext.SaveChangesAsync();
        }

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
