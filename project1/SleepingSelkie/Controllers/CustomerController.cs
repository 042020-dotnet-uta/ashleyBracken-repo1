using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SleepingSelkieBusinessLogic.IRepositories;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkie.Models;
using Microsoft.AspNetCore.Routing;

namespace SleepingSelkie.Controllers
{
    public class CustomerController : Controller
    {
        
        private readonly IInventoryRepository inventoryRepository;
        private readonly ICustomerRepository custRepository;
        public static string curCustName { get; set; }
        public string curCustphoneNumber { get; set; }
        public CustomerController(IInventoryRepository repository, ICustomerRepository customerRepository)
        {
            inventoryRepository = repository;
            custRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            var modelView = new LoginViewModel { };
            ViewBag.Message = "Customer Login";
            return View(modelView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            int id;
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = await custRepository.GetCustomerByName(viewModel.FirstName, viewModel.LastName);
                    curCustName = customer.FirstName + customer.LastName;
                    curCustphoneNumber = customer.PhoneNumber;
                    HttpContext.Session.SetString("CustName",curCustName);
          
                    if (customer.StoreName == "SleepingSelkiePrimaryLocation")
                    {
                        id = 1;
                    }
                    else if (customer.StoreName == "SleepingSelkieSecondaryLocation")
                    {
                        id = 2;
                    }
                    else id = 3;

                    return RedirectToAction("Inv", "Customer", new { @id = id });

                }
                else return View("Index", "Home");
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("That didn't work", e.Message);
            }
            catch (NullReferenceException e)
            {
                ModelState.AddModelError("Customer Not Found", e.Message);
            }
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
                    int id;
                    curCustName = viewModel.FirstName;
                    curCustphoneNumber = viewModel.PhoneNumber;
                    if (viewModel.storeName.ToString() == "SleepingSelkiePrimaryLocation")
                    {
                        id = 1;
                    }
                    else if (viewModel.storeName.ToString() == "SleepingSelkieSecondaryLocation")
                    {
                        id = 2;
                    }
                    else id = 3;

                    var customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        PhoneNumber = viewModel.PhoneNumber,
                        StoreName = viewModel.storeName.ToString(),
                    };
                    await custRepository.AddCustomerAsync(customer);

                    return RedirectToAction("Inv","Customer",new { @id=id});
                }
                else return View(viewModel);
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