using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieDataAccess.Repositories
{
    class InventoryRepository : IInventoryRepository
    {
        public Task<IEnumerable<Inventory>> GetAllInvByStoreID(int storeID)
        {
            throw new NotImplementedException();
        }
    }
}
