using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SleepingSelkie.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult SignUp()
        {
            ViewBag.Message = "Customer Sign Up";
            return View();
        }
    }
}