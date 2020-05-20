using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SleepingSelkieBusinessLogic.BusinessModels;

namespace SleepingSelkieBusinessLogic.IRepositories
{/// <summary>
/// Product repository which acts as an intermediary between the product model and the data model
/// </summary>
  public  interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductsByName(string productName);
    }
}
