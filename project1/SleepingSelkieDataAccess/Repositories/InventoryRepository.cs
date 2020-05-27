
using Microsoft.EntityFrameworkCore;
using SleepingSelkieBusinessLogic.IRepositories;
using System.Collections.Generic;
using System.Linq;
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
        public async Task DecreaseInventory(string productName,string storeName, int purchasedAmount)
        {
            var curInventory = await dbContext.Inventories
            .Include(x=>x.Store)
            .Include(x=>x.Products)
             .Where(i => i.Store.StoreName == storeName)
             .Where(p => p.Products.ProductName == productName).FirstOrDefaultAsync();
               curInventory.ProductQuantity-=purchasedAmount;
              dbContext.SaveChangesAsync();
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
