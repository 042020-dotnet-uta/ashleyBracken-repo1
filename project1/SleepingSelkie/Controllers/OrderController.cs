using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SleepingSelkie.Models;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;

namespace SleepingSelkie.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        public OrderController(IOrdersRepository orders)
        {
            ordersRepository = orders;
        }
        public IActionResult Index()
        {
            return View();
        }

         [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<ActionResult> Order(InventoryViewModel inventoryView)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    var order = new Orders
                    {
                        Customer = HttpContext.Session.GetString("CustName"),

                    };
                }
            }
            catch  (InvalidOperationException e)
            { 
            }
            return View();
        }

    }
}