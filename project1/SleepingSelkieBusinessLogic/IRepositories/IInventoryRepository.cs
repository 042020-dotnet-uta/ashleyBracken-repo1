using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieBusinessLogic.IRepositories
{
    /// <summary>
    /// Inventory interface which acts as an intermediary between the data models and business models.
    /// </summary>
  public  interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAllInvByStoreID(int storeName);
        Task DecreaseInventory(string productID,string storeName, int purchasedAmount);
    }
}
