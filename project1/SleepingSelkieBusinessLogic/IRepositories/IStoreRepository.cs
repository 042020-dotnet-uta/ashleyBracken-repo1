using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieBusinessLogic.IRepositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStores();
        Task<Store> GetStoreByID(int id);
    }
}
