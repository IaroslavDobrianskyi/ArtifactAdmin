using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;

namespace ArtifactAdmin.Web.Controllers
{
    using Models;

    public class TestPathController : Controller
    {
        private IStepFinderService stepFinderService;

        public TestPathController(IStepFinderService stepFinderService)
        {
            this.stepFinderService = stepFinderService;
        }

        // GET: TestPath
        public ActionResult Index()
        {
            return View(new TestPathModel());
        }

        public ActionResult GetPoints()
        {
            //var pts = new List<Point>();
            //Random rnd = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    pts.Add(new Point(rnd.Next(1000), rnd.Next(1000)));
            //}

            var pts = stepFinderService.GetPathPoints();

            return Json(pts, JsonRequestBehavior.AllowGet);
        }
    }
}