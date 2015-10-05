namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using BL.Interfaces;
    using Models;

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
