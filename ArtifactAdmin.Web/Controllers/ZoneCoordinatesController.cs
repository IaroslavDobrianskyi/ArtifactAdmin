﻿namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.Utils;
    using Models;

    public class ZoneCoordinatesController : Controller
    {
        private IMapZoneService mapZoneService;
        private IZoneCoordinatesService zoneCoordinatesService;
        private IMapInfoService mapInfoService;


        public ZoneCoordinatesController(IZoneCoordinatesService zoneCoordinatesService, IMapInfoService mapInfoService, IMapZoneService mapZoneService) 
        {
            this.zoneCoordinatesService = zoneCoordinatesService;
            this.mapInfoService = mapInfoService;
            this.mapZoneService = mapZoneService;
        }

        //
        // GET: /ZoneCoordinates/

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

             var coordinates = zoneCoordinatesService.GetZoneValuesCoordinatByMapInfoId(id);
            var count = 0;
            if (coordinates.Count() > 0)
            {
                foreach (var key in coordinates.Keys)
                {
                    count += coordinates[key].Count;
                }
            }

            var model = new ZoneCoordinatesInfoModel()
                {
                    MapInfoId = id.Value,
                    LinesCount = count
                };

           

            return View(model);
        }

        public ActionResult Create(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            
            try
            {
                mapZoneService.EnshureAllZonesPresentInMapInfo(id);
                zoneCoordinatesService.CreateZoneCoordinates(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при створенні нового запису";
                ViewBag.ErrMes = e.Message;
                return RedirectToAction("Index",new {id=id});
            }

            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;

            try
            {
                
                zoneCoordinatesService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при створенні нового запису";
                ViewBag.ErrMes = e.Message;
                return RedirectToAction("Index", new { id = id });
            }

            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult ImageFromZoneCoordinates(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mapInfo = this.mapInfoService.GetById(id);
            if (mapInfo == null)
            {
                return HttpNotFound();
            }

            var coordinates = zoneCoordinatesService.GetZoneValuesCoordinatByMapInfoId(id);

            if (coordinates.Count() > 0)
            {

                var img = new Bitmap(mapInfo.Width, mapInfo.Height);
                var cc = new ColorConverter();
                foreach (var key in coordinates.Keys)
                {
                    var color = (Color)cc.ConvertFromString(key);
                    foreach (var item in coordinates[key])
                    {
                        img.SetPixel(item.X, item.Y, color);
                    }
                }

                return base.File(img.ToStream(ImageFormat.Bmp), "image/jpeg");
            }
            else
            {
                return new EmptyResult();
            }
        }

    }
}
