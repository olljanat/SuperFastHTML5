using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;

namespace ExampleMVC.Controllers
{
    [OutputCache(Duration = 0, VaryByParam = "none", Location = OutputCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 43200, VaryByParam = "none", Location = OutputCacheLocation.Any, NoStore = false)]
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
    }
}