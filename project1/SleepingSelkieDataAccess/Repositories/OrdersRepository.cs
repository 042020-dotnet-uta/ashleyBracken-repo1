using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace SleepingSelkieDataAccess.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly SelkieContext dbContext;

        public OrdersRepository(SelkieContext selkieContext)
        {
            dbContext = selkieContext;
        }
        #region Add NewOrder
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
        #endregion
        public async Task<IEnumerable<Orders>> GetOrdersByCustomer(string customerID)
        {
            var orders = await dbContext.Orders
                .Include(x => x.Store)
                .Include(x => x.Customer)
                .Where(x => x.Customer.CustomerID == customerID).ToListAsync();
            return orders.Select(x => new SleepingSelkieBusinessLogic.BusinessModels.Orders
            {
                StoreName = x.Store.StoreName,
                CustomerID = x.Customer.CustomerID,
                ManaPotionsBought = x.ManaPotionsBought,
                StaminaPotionsBought = x.StaminaPotionsBought,
                HealthPotionsBought = x.HealthPotionsBought,
                ClericsTalismanBought = x.ClericsTalismanBought,
                MagicWandsBought = x.ClericsTalismanBought,
                Date =x.Date,
            });
      
        }

        public Task<IEnumerable<Orders>> GetOrdersByStore(int storeID)
        {
            throw new NotImplementedException();
        }
    }
}
