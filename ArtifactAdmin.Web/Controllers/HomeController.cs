// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;

namespace ArtifactAdmin.Web
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
    }
}