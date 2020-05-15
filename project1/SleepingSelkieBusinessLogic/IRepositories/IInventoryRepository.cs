using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieBusinessLogic.IRepositories
{
  public  interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAllInvByStoreID(int storeID);
        Task DecreaseInventory(int productID,int storeID, int purchasedAmount);
    }
}
