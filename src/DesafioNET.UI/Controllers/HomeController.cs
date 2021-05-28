using DesafioNET.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioNET.UI.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {


            return View();
        }


        public IActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImportFile()
        {


            return RedirectToAction("Account");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
