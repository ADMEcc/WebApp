using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADME_Website.Models;

namespace ADME_Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Donate()
        {
            return View();

        }

        public IActionResult News()
        {
            return View();

        }

        public IActionResult TokenSale()
        {
            return View();

        }

        //[HttpGet]
        //public string TokenSale()
        //{
        //    return "/Home/Donate";
        //}

        //public void Whitepaper()
        //{
        //    Response.Redirect("../images/Cute-siberian-husky-puppy-on-grass-892x892.jpg");
        //}

        public IActionResult AMA()
        {
            return View();
        }

        //public IActionResult Whitepaper()
        //{
        //    return View();
        //}

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
