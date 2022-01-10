using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCIntroduction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Name = "Jonathan";      //ViewBag and Data are the same. 
            ViewData["Name"] = "Sammy";  //If you change name to Sammy, viewbag.name will be overridden.
            TempData["YourName"] = "Jonathan"; //Unlike above pair, TempData provides data to other pages.
            return View();
        }
    }
}