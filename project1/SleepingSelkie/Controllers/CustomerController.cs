using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SleepingSelkieBusinessLogic.IRepositories;
using SleepingSelkieBusinessLogic;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkie.Models;
using SleepingSelkieDataAccess.Repositories;
using Microsoft.AspNetCore.Identity;

namespace SleepingSelkie.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IInventoryRepository inventoryRepository;

        public CustomerController(IInventoryRepository repository)
        {
            inventoryRepository = repository;
        }
        public ActionResult SignUp()
        {
            ViewBag.Message = "Customer Sign Up";
            return View();
        }

        public async Task<ActionResult>  Inv (int id)
        {
            IEnumerable<Inventory> inv = await inventoryRepository.GetAllInvByStoreID(id);
            var invModels = inv.Select(i => new InventoryViewModel
            {
                StoreName = i.StoreName,
                ProductName =i.ProductName,
                ProductDescription = i.ProductDescription,
                Price = i.ProductPrice,
                Quantity = i.ProductQuantity,

            }) ;
            return View(invModels);
        }
    }
}