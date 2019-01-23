using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DN_Lab11_My_First_MVC_App.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DN_Lab11_My_First_MVC_App.Controllers
{
    public class HomeController : Controller
{
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            if(startYear <= endYear)
            {
                return RedirectToAction("Result", new { startYear, endYear });
            }
            else
            {
                return RedirectToAction("Index");
            }           
        }
        
        public IActionResult Result(int startYear, int endYear)
        {
            List<Person> filteredPeople = Person.Search(startYear, endYear);
            return View(filteredPeople);
        }
    }
}
