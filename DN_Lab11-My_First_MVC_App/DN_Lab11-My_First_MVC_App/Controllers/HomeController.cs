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
        /// <summary>
        /// Default page that is rendered when site is loaded.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// When submit button is pressed checks input data to make sure that it fits the query requirements and that a field has been populated. Once validated it sends input data to the result controller. If data is invalid it will reroute to index.
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            if (startYear == 0 || endYear == 0)
            {
                return RedirectToAction("Index");
            }
            if (startYear <= endYear)
            {
                return RedirectToAction("Result", new { startYear, endYear });
            }
            else
            {
                return RedirectToAction("Index");
            }           
        }

        /// <summary>
        /// Receives submit button data and runs a search then sends the filteredData to the results page and loads it.
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Result(int startYear, int endYear)
        {
            List<Person> filteredPeople = Person.Search(startYear, endYear);
            return View(filteredPeople);
        }
    }
}
