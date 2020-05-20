using SleepingSelkieBusinessLogic.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieBusinessLogic.IRepositories
{/// <summary>
/// Repository which acts as an intemediary between store data model and store business model.
/// </summary>
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStores();
        Task<Store> GetStoreByID(int id);
    }
}
