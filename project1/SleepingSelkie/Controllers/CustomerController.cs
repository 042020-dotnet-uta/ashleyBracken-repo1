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
        private readonly ICustomerRepository custRepository;
        private string curCustName;
        private string curCustphoneNumber;
        public CustomerController(IInventoryRepository repository, ICustomerRepository customerRepository)
        {
            inventoryRepository = repository;
            custRepository = customerRepository;
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Customer Login";
            return View();
        }
        public ActionResult SignUp()
        {
            var modelView = new CustomerViewModel { };
            ViewBag.Message = "Customer Sign Up";
            return View(modelView);
        }

      [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(CustomerViewModel viewModel)
        {
            try 
            {
                //Serverside validation to double check the info provided
                if (ModelState.IsValid)
                {
                    curCustName = viewModel.FirstName;
                    curCustphoneNumber = viewModel.PhoneNumber;
                    var customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        PhoneNumber = viewModel.PhoneNumber,
                        StoreName = viewModel.storeName.ToString(),
                    };
                    await custRepository.AddCustomerAsync(customer);

                    return RedirectToAction("Home");
                }
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("Invalid Customer Info", e.Message);
                return View(viewModel);
            }
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