using Microsoft.EntityFrameworkCore;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using SleepingSelkieDataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieDataAccess.Repositories
{
    class StoreRepository : IStoreRepository
    {
        private readonly SelkieContext dbContext;

        public StoreRepository(SelkieContext selkieContext)
        {
            dbContext = selkieContext;
        }
        public async Task<IEnumerable<SleepingSelkieBusinessLogic.BusinessModels.Store>> GetAllStores()
        {
            List<DataModels.Store> stores = await dbContext.Stores.ToListAsync();
            return stores.Select(s => new SleepingSelkieBusinessLogic.BusinessModels.Store
            {
                StoreName = s.StoreName,
                StoreID = s.StoreID,
            }) ;
        }

        public async Task<SleepingSelkieBusinessLogic.BusinessModels.Store> GetStoreByID(int id)
        {
            var selectedStore = await dbContext.Stores.Where(s => s.StoreID == id).FirstOrDefaultAsync();
            return new SleepingSelkieBusinessLogic.BusinessModels.Store
            {
                StoreID = selectedStore.StoreID,
                StoreName = selectedStore.StoreName
            };
           // throw new NotImplementedException();
        }
    }
}
