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
        #region OrderList and save current order to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Order(OrderListModel listModel)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    for (var i = 0;i<listModel.order.Count;i++)
                    {
                        if (listModel.order[i].Quantity <listModel.order[i].OrderAmount)
                        {
                            ViewBag.Message = string.Format("You have chosen more than the available inventory on One or more Items");
                            return RedirectToAction("Inv", "Customer");
                        }
                    }
                    #region Set Current Order View Model Info
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
                    #endregion
                    #region Set New Order
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
                    #endregion
                }
                else
                {
                    ModelState.AddModelError("InvalidOrderInfo", "You most likely tried to order more than what is in Stock of an item, please try again");
                    return RedirectToAction("Inv", "Customer");
                }
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("InvalidOrderInfo", "You most likely tried to order more than what is in Stock of an item, please try again");
                return View();
            }

        }
    
        #endregion

        /*  public async Task<ActionResult> customerOrders()
          { 

          }*/
    }
}