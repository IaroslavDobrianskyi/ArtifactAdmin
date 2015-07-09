using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Art.Models;


namespace Art.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // створюю записи
            int kStep=50;
            int kAct=10;
            Art.App_code flow=new App_code();
            flow.Run(50, kStep, kAct);
            

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
    }
}