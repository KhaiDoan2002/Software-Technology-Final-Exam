using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TESTVS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is the website built by Ho Tuan Kiet and Nguyen Doan Minh Khai";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacting us for more details";

            return View();
        }
    }
}