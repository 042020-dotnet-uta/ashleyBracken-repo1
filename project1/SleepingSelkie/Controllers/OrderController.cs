using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SleepingSelkie.Controllers;
using SleepingSelkieBusinessLogic.BusinessModels;
using SleepingSelkieBusinessLogic.IRepositories;
using SleepingSelkie.Models;

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
        public async  Task <ActionResult> Order (OrderListModel listModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewModel = new OrderViewModel
                    {
                        CustomerName = HttpContext.Session.GetString("CustName"),
                        StoreName = listModel.order.Select(x => x.StoreName).FirstOrDefault(),
                        CustomerPhoneNumber = HttpContext.Session.GetString("CustPhoneNumber"),
                        ManaPotionsBought = listModel.order
                        .Where(x => x.ProductName == "Mana Potion").Select(x => x.OrderAmount).FirstOrDefault(),
                        ClericsTalismanBought = listModel.order
                        .Where(x => x.ProductName == "Clerics Talisman").Select(x => x.OrderAmount).FirstOrDefault(),
                        HealthPotionsBought = listModel.order
                        .Where(x => x.ProductName == "Health Potion").Select(x => x.OrderAmount).FirstOrDefault(),
                        StaminaPotionsBought = listModel.order
                        .Where(x => x.ProductName == "Stamina Potion").Select(x => x.OrderAmount).FirstOrDefault(),
                        MagicWandsBought = listModel.order
                        .Where(x => x.ProductName == "Magic Wand").Select(x => x.OrderAmount).FirstOrDefault(),
                        Date = DateTime.Today,
                    };

                    var order = new Orders
                    {
                        CustomerID = viewModel.CustomerPhoneNumber,
                        StoreName = viewModel.StoreName,
                        ManaPotionsBought = viewModel.ManaPotionsBought,
                        StaminaPotionsBought = viewModel.StaminaPotionsBought,
                        HealthPotionsBought = viewModel.HealthPotionsBought,
                        ClericsTalismanBought = viewModel.ClericsTalismanBought,
                        MagicWandsBought = viewModel.ClericsTalismanBought,
                        Date = DateTime.Today,
                    };
                    await ordersRepository.AddOrdersAsync(order);
                    return View(viewModel);
                }
                else return RedirectToAction("Index", " Home");
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("Invalid Order Info", e.Message);
                return RedirectToAction("Index", " Home");
            }
        }

    }
}