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
using Microsoft.Extensions.Logging;

namespace SleepingSelkie.Controllers
{
    public class OrderController : Controller
    {
        int selectedStore = 0;
        private readonly IOrdersRepository ordersRepository;
        private readonly IInventoryRepository inventory;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrdersRepository orders, IInventoryRepository inventoryRepository, ILogger<OrderController> logger)
        {
            ordersRepository = orders;
            inventory = inventoryRepository;
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Recieves the Inventory List Form and posts the info into the 
        /// Order View List so I can use it 
        /// </summary>
        /// <param name="listModel"></param>
        /// <returns></returns>
        #region OrderList and save current order to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Order(OrderListModel listModel)
        {

            try
            {///Checks if Model state is valid
                if (ModelState.IsValid)
                {
                    for (var i = 0; i < listModel.order.Count; i++)
                    {
                        if (listModel.order[i].Quantity < listModel.order[i].OrderAmount)
                        {
                            ViewBag.Message = string.Format("You have chosen more than the available inventory on One or more Items");
                           await  inventory.DecreaseInventory(listModel.order[i].ProductName, listModel.order[i].StoreName,listModel.order[i].OrderAmount);
                            _logger.LogInformation("You have tried to Order too much");
                            return RedirectToAction("Inv", "Customer");
                        }
                    }
                  ///Sets Current order view model info
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
                    /// Creates a new order to save to db
                    #region Set New Order
                    var order = new Orders
                    {
                        ///Sets the values to be saved as an order
                        CustomerID = viewModel.CustomerPhoneNumber,
                        StoreName = viewModel.StoreName,
                        ManaPotionsBought = viewModel.ManaPotionsBought,
                        StaminaPotionsBought = viewModel.StaminaPotionsBought,
                        HealthPotionsBought = viewModel.HealthPotionsBought,
                        ClericsTalismanBought = viewModel.ClericsTalismanBought,
                        MagicWandsBought = viewModel.ClericsTalismanBought,
                        Date = DateTime.Today,
                    };
                    ///Add Order to db
                    await ordersRepository.AddOrdersAsync(order);
                    ///return created viewmodel
                    return View(viewModel);
                    #endregion
                }
                else
                {/// Don't save and redirect back to inventory
                    ModelState.AddModelError("InvalidOrderInfo", "You most likely tried to order more than what is in Stock of an item, please try again");
                    return RedirectToAction("Inv", "Customer");
                }
            }///catch exception
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("InvalidOrderInfo", "You most likely tried to order more than what is in Stock of an item, please try again");
                return View();
            }

        }
        #endregion
        /// <summary>
        /// Retrieves the info from the orders repository and a
        /// assigns it to to its correlating order, creates an I enumerable 
        /// out of the data which is then passed into a view that iterates through 
        /// the list 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CustomerOrders()
        {
            IEnumerable<Orders> orders = await ordersRepository.GetOrdersByCustomer(HttpContext.Session.GetString("CustPhoneNumber"));
            var orderModels = orders.Select(x => new OrderViewModel
            {
                CustomerPhoneNumber = x.CustomerID,
                CustomerName = x.CustomerName,
                StoreName = x.StoreName,
                ManaPotionsBought =x.ManaPotionsBought,
                HealthPotionsBought =x.HealthPotionsBought,
                StaminaPotionsBought =x.StaminaPotionsBought,
                MagicWandsBought =x.MagicWandsBought,
                ClericsTalismanBought=x.ClericsTalismanBought,
                Date=x.Date,

            });
            return View(orderModels);
        }
        #region Select Store Actions for LayoutPage
        /// <summary>
        /// Sets a store value to figure out which store the customer is looking at
        /// </summary>
        /// <returns></returns>
        public ActionResult setStoreA()
        {
            HttpContext.Session.SetInt32("Store", 1);
          return  RedirectToAction("StoreOrders", "Order");
        }
        /// <summary>
        /// Sets a session value to return which store a customer is looking at
        /// </summary>
        /// <returns></returns>
        public ActionResult setStoreB()
        {
            HttpContext.Session.SetInt32("Store", 2);
            return RedirectToAction("StoreOrders", "Order");
        }
        /// <summary>
        /// Sets a Session value to store which store the customer is looking at
        /// </summary>
        /// <returns></returns>
        public ActionResult setStoreC()
        {
            HttpContext.Session.SetInt32("Store", 3);
            return RedirectToAction("StoreOrders", "Order");
        }
        #endregion
        /// <summary>
        /// Checks the store value that is saved in the session and 
        /// returns a correlating IEnumerable from the Database 
        /// that is then iterated through in a list 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> StoreOrders()
        {
            var id =1;
            if (HttpContext.Session.GetInt32("Store") == 1)
            {
                id = 1;
            }
            else if (HttpContext.Session.GetInt32("Store") == 2)
            {
                id = 2;
            }
            else id = 3;
            IEnumerable<Orders> orders = await ordersRepository.GetOrdersByStore(id);
            var orderModels = orders.Select(x => new OrderViewModel
            {
                CustomerPhoneNumber = x.CustomerID,
                CustomerName = x.CustomerName,
                StoreName = x.StoreName,
                ManaPotionsBought = x.ManaPotionsBought,
                HealthPotionsBought = x.HealthPotionsBought,
                StaminaPotionsBought = x.StaminaPotionsBought,
                MagicWandsBought = x.MagicWandsBought,
                ClericsTalismanBought = x.ClericsTalismanBought,
                Date = x.Date,

            });
            return View(orderModels);
        }

    }
}