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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly SelkieContext dbContext;

        public InventoryRepository(SelkieContext selkieContext)
        {
            dbContext = selkieContext;
        }
        public async Task DecreaseInventory(int productID,int storeName, int purchasedAmount)
        {
            var curInventory = await dbContext.Inventories
             .Where(i => i.Store.StoreID == storeName)
             .Where(p => p.Products.ProductID == productID)
             .Select(q => q.ProductQuantity).FirstAsync();
            curInventory -= purchasedAmount;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SleepingSelkieBusinessLogic.BusinessModels.Inventory>> GetAllInvByStoreID(int storeID)
        {
            var inventories = await dbContext.Inventories
           .Include(p=>p.Products)
            .Include(s=>s.Store)
            .Where(i => i.Store.StoreID == storeID).ToListAsync();

            return inventories.Select(s => new SleepingSelkieBusinessLogic.BusinessModels.Inventory
            {
                InventoryID = s.InventoryID,
                ProductQuantity = s.ProductQuantity,
                ProductName =s.Products.ProductName,
                StoreName = s.Store.StoreName,
                ProductDescription = s.Products.ProductDescription,
                ProductPrice = s.Products.ProductPrice,
            })  ; 
        }
    }
}
