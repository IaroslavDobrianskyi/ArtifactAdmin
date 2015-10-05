using System;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.Web.Models;

namespace ArtifactAdmin.Web.Controllers
{
    public class TestMapController : Controller
    {
        private IMapManagerService mapManagerService;


        public TestMapController(IMapManagerService mapManagerService) 
        {
            this.mapManagerService = mapManagerService;
        }
        //
        // GET: /TestMap/

        public ActionResult Index()
        {
            
            
            var startTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            var mapManager = mapManagerService.GetFirstMapManager();
            var milliSecondsToLoadMap = DateTime.Now.TimeOfDay.TotalMilliseconds - startTime;

            
            return View(new TestMapModel()
                {
                    MilisecondsToLoadMap = (int)milliSecondsToLoadMap,
                    MapName = mapManager.MapName,
                    Width = mapManager.Width,
                    Height = mapManager.Height,
                    AlaivableDimentionsAndRadiuses = mapManager.AvailableDimentionAndRadiuses
                });
        }

    }
}
