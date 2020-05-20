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
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

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

            try
            {
                if (ModelState.IsValid)
                {
                    var customer = await custRepository.GetCustomerByName(viewModel.FirstName, viewModel.LastName);
                    curCustName = customer.FirstName + " " + customer.LastName;
                    curCustphoneNumber = customer.PhoneNumber;
                    HttpContext.Session.SetString("CustName", curCustName);
                    HttpContext.Session.SetString("CustPhoneNumber", curCustphoneNumber);
                    HttpContext.Session.SetString("PreferredStore", customer.StoreName);
                    return RedirectToAction("Inv", "Customer");

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
                    HttpContext.Session.SetString("PreferredStore", viewModel.storeName.ToString());
                    var customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        PhoneNumber = viewModel.PhoneNumber,
                        StoreName = viewModel.storeName.ToString(),
                    };
                    await custRepository.AddCustomerAsync(customer);
                    return RedirectToAction("Inv", "Customer");
                }
                else return View(viewModel);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("Invalid Customer Info", e.Message);
                return View(viewModel);
            }
        }
        public ActionResult GoToMyStore()
        {
            if (HttpContext.Session.GetString("CustName") != null)
            {
                
                return RedirectToAction("Inv", "Customer");
            }
            else return RedirectToAction("Login", "Customer");
        }

        public async Task<ActionResult> Inv()
        {
            int id = 1;
            if (HttpContext.Session.GetString("PreferredStore") == "SleepingSelkiePrimaryLocation")
            {
              id = 1;
            }
            if (HttpContext.Session.GetString("PreferredStore")== "SleepingSelkieSecondaryLocation")
            {
            }
            else id = 3;
            IEnumerable<Inventory> inv = await inventoryRepository.GetAllInvByStoreID(id);
            var invModels = inv.Select(i => new InventoryViewModel
            {
                StoreName = i.StoreName,
                ProductName = i.ProductName,
                ProductDescription = i.ProductDescription,
                Price = i.ProductPrice,
                Quantity = i.ProductQuantity,
                OrderAmount = 0,

            }).ToList();
            return View(invModels); 
        }
    }
}