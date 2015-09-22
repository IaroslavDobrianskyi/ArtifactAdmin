using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.MapHelpers;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;
using ArtifactAdmin.Web.Models;

namespace ArtifactAdmin.Web.Controllers
{
    public class MapInfoDimensionController : Controller
    {

        private IMapInfoDimensionService mapInfoDimensionService;
        private IMapInfoService mapInfoService;
        private IZoneCoordinatesService zoneCoordinatesService;

        public MapInfoDimensionController(IMapInfoDimensionService mapInfoDimensionService, IMapInfoService mapInfoService, IZoneCoordinatesService zoneCoordinatesService) 
        {
            this.mapInfoDimensionService = mapInfoDimensionService;
            this.mapInfoService = mapInfoService;
            this.zoneCoordinatesService = zoneCoordinatesService;
        }

        //
        // GET: /MapInfoDimension/id

        public ActionResult Index()
        {

            return View(mapInfoDimensionService.GetAll());
            
        }

        // GET: MapInfoDimension/Create
        public ActionResult Create()
        {
            return View(new MapInfoDimensionCreateModel()
                {
                    MapInfoDimensionDto = new MapInfoDimensionDto(),
                    AvailableMapInfos = mapInfoService.GetAll()
                });
        }

        // POST: MapInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dimension,MapInfo")]MapInfoDimensionDto mapInfoDimensionDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapInfoDimensionService.Create(mapInfoDimensionDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(mapInfoDimensionDto);
                }

                return RedirectToAction("Index");
            }

            return View(mapInfoDimensionDto);
        }

        // GET: MapInfoDimension/Create
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapInfoDimension = mapInfoDimensionService.GetById(id);
            return View(mapInfoDimension);
        }



        public ActionResult MiddlePointsImage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapInfoDimention = mapInfoDimensionService.GetById(id);
            


            var middlePoints = mapInfoDimensionService.GetMiddlePointsForDimension(id);


            if (middlePoints.Count() > 0)
            {
                var dic = new Dictionary<SimplePoint, LinesContainer>();
                var dicColors = new Dictionary<SimplePoint, Color>();

                foreach (var c in middlePoints)
                {
                    var color = ColorHelper.GetRandomColor();
                    dic.Add(new SimplePoint()
                        {
                            X = c.X,
                            Y = c.Y,
                        }, LinesContainer.Deserialize(c.RelatedCoordinates));
                    dicColors.Add(new SimplePoint()
                        {
                            X = c.X,
                            Y = c.Y,
                        }, color);
                }

                var img = new Bitmap(mapInfoDimention.MapInfo1.Width, mapInfoDimention.MapInfo1.Height);
                var cc = new ColorConverter();
                foreach (var key in dic.Keys)
                {
                    var color = dicColors[key];
                    foreach (var line in dic[key].Lines)
                    {
                        for (int x = line.StartX; x <= line.EndX; x++)
                        {
                            img.SetPixel(x, line.Y, color);
                        }
                    }
                    img.SetPixel(key.X, key.Y, Color.FromKnownColor(KnownColor.Black));
                }

                return base.File(img.ToStream(ImageFormat.Bmp), "image/jpeg");
            }
            else
            {
                return new EmptyResult();
            }
        }

        public ActionResult ImageFromZoneCoordinatesWithMiddplePoints(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mapInfoDimention = mapInfoDimensionService.GetById(id);

            var middlePoints = mapInfoDimensionService.GetMiddlePointsForDimension(id);

            var coordinates = zoneCoordinatesService.GetZoneCoordinatByMapInfoId(mapInfoDimention.MapInfo);

            if (coordinates.Count() > 0)
            {
                var dic = new Dictionary<string, LinesContainer>();

                foreach (var c in coordinates)
                {
                    dic.Add(c.MapZone1.Color, LinesContainer.Deserialize(c.Coordinates));
                }

                var img = new Bitmap(mapInfoDimention.MapInfo1.Width, mapInfoDimention.MapInfo1.Height);
                var cc = new ColorConverter();
                foreach (var key in dic.Keys)
                {
                    var color = (Color)cc.ConvertFromString(key);
                    foreach (var line in dic[key].Lines)
                    {
                        for (int x = line.StartX; x <= line.EndX; x++)
                        {
                            img.SetPixel(x, line.Y, color);
                        }
                    }

                }

                foreach (var mp in middlePoints)
                {
                    img.SetPixel(mp.X, mp.Y, Color.FromKnownColor(KnownColor.Black));
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
