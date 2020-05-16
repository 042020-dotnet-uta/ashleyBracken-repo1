using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SleepingSelkieBusinessLogic.IRepositories;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkie.Models;

namespace SleepingSelkie.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly ICustomerRepository custRepository;
        private string curCustName;
        private string curCustphoneNumber;
        private int storeid;
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

        [HttpGet]
        public ActionResult SignUp()
        {
            var modelView =  new CustomerViewModel { };
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
                    if (viewModel.storeName.ToString() == "SleepingSelkiePrimaryLocation")
                    {
                        storeid = 1;
                    }
                    if (viewModel.storeName.ToString()== "SleepingSelkieSecondaryLocation")
                    {
                        storeid = 2;
                    }
                    if (viewModel.storeName.ToString() == "SleepingSelkieLocation3")
                    { 
                       storeid = 3;
                    }
                    var customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        PhoneNumber = viewModel.PhoneNumber,
                        StoreName = viewModel.storeName.ToString(),
                    };
                    await custRepository.AddCustomerAsync(customer);

                    return RedirectToAction("Inv");
                }
                else return View(viewModel);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("Invalid Customer Info", e.Message);
                return View(viewModel);
            }
        }
        public async Task<ActionResult>  Inv ()
        {
            IEnumerable<Inventory> inv = await inventoryRepository.GetAllInvByStoreID(storeid);
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