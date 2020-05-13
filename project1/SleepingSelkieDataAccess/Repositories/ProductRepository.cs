using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SleepingSelkieDataAccess.Repositories
{
    class ProductRepository : IProductRepository
    {
        public Task<IEnumerable<Products>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Products> GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
