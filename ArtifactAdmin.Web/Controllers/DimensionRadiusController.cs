using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.Web.Models;

namespace ArtifactAdmin.Web.Controllers
{
    public class DimensionRadiusController : Controller
    {
        private IDimentionRadiusService dimentionRadiusService;
        private IMapInfoDimensionService mapInfoDimensionService;

        public DimensionRadiusController(IDimentionRadiusService dimentionRadiusService, IMapInfoDimensionService mapInfoDimensionService)
        {
            this.dimentionRadiusService = dimentionRadiusService;
            this.mapInfoDimensionService = mapInfoDimensionService;

        }

        //
        // GET: /DimensionRadius/

        public ActionResult Index()
        {
            return View(dimentionRadiusService.GetAll());
        }

        // GET: DimensionRadius/Create
        public ActionResult Create()
        {
            var model = new DimentionRadiusModel()
                {
                    AvailableMapInfoDimensionDtos =
                        mapInfoDimensionService.GetAll().Select(x => new MapInfoAndDimensionModel()
                            {
                                Id = x.Id,
                                MapInfoAndDimension = x.MapInfo1.MapName + " " + x.Dimension
                            }).ToList(),
                    DimentionRadiuDto = new DimentionRadiuDto()
                };
            return View(model);
        }


        // POST: DimensionRadius/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapInfoDimension,Radius")] DimentionRadiuDto dimentionRadiusDto)
        {
            
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.dimentionRadiusService.Create(dimentionRadiusDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(dimentionRadiusDto);
                }

                return RedirectToAction("Index");
            }

            return View(dimentionRadiusDto);
        }
    }
}
