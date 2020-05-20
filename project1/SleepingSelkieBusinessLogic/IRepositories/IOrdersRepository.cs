using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieBusinessLogic.IRepositories
{
    /// <summary>
    /// Order Interface which acts as an intermediary between the business model and data model. 
    /// </summary>
   public interface IOrdersRepository
    {
        Task AddOrdersAsync(Orders order);
        Task<IEnumerable<Orders>> GetOrdersByStore(int storeID);
        Task<IEnumerable<Orders>> GetOrdersByCustomer(string customerID);
    }
}
