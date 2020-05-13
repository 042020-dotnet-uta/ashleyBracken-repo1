using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SleepingSelkieBusinessLogic.BusinessModels;

namespace SleepingSelkieBusinessLogic.IRepositories
{
  public  interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductsByName(string productName);
    }
}
