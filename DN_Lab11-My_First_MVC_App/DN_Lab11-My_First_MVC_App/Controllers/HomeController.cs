using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_Lab11_My_First_MVC_App.Controllers
{
    public class HomeController : Controller
{
        public IActionResult Index()
        {
            return View();
        }
    }
}
