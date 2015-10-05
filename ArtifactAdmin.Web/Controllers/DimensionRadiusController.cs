namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;
    using BL.Utils;
    using Models;

    public class DimensionRadiusController : Controller
    {
        private IDimentionRadiusService dimentionRadiusService;
        private IMapInfoDimensionService mapInfoDimensionService;
        private IZoneCoordinatesService zoneCoordinatesService;
        private IMiddlePointNeighborsService middlePointNeighborsService;

        public DimensionRadiusController(IDimentionRadiusService dimentionRadiusService, IMapInfoDimensionService mapInfoDimensionService, IZoneCoordinatesService zoneCoordinatesService, IMiddlePointNeighborsService middlePointNeighborsService)
        {
            this.dimentionRadiusService = dimentionRadiusService;
            this.mapInfoDimensionService = mapInfoDimensionService;
            this.zoneCoordinatesService = zoneCoordinatesService;
            this.middlePointNeighborsService = middlePointNeighborsService;
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
        public ActionResult Create(DimentionRadiusModel dimentionRadiusModel)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.dimentionRadiusService.Create(dimentionRadiusModel.DimentionRadiuDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(dimentionRadiusModel);
                }

                return RedirectToAction("Index");
            }

            return View(dimentionRadiusModel);
        }

        // GET: MapInfoDimension/Create
        public ActionResult Details(int? id, int? p1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dimentionRadius = dimentionRadiusService.GetById(id);
            return View(new DimentionRadiusModelDetails()
                {
                    DimentionRadiuDto = dimentionRadius,
                    Count = dimentionRadius.MiddlePointNeighbors.Count,
                    Index = p1.HasValue ? p1.Value : 0
                });
        }


        public ActionResult ImageForDimentionRadius(int? id, int? index)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dimentionRadiusDto = dimentionRadiusService.GetById(id);

            var coordinates = zoneCoordinatesService.GetZoneValuesCoordinatByMapInfoId(dimentionRadiusDto.MapInfoDimension1.MapInfo);

            var middlePointNeighbors =
                middlePointNeighborsService.GetMiddlePointNeighborsByDimentionRadius(dimentionRadiusDto.Id);
            

            if (coordinates.Count() > 0)
            {
                var img = new Bitmap(dimentionRadiusDto.MapInfoDimension1.MapInfo1.Width, dimentionRadiusDto.MapInfoDimension1.MapInfo1.Height);

                var cc = new ColorConverter();
                foreach (var key in coordinates.Keys)
                {
                    var color = (Color)cc.ConvertFromString(key);
                    foreach (var item in coordinates[key])
                    {
                        img.SetPixel(item.X, item.Y, color);
                    }

                }
                using (var graphics = Graphics.FromImage(img))
                {
                    var mp = middlePointNeighbors.Keys.ElementAt(index.Value);
                    var randomColor = ColorHelper.GetRandomColor();
                    
                    img.SetPixel(mp.X, mp.Y, randomColor);

                    var neighbors = middlePointNeighbors[mp];
                    foreach (var simplePoint in neighbors)
                    {
                        var pen = new Pen(ColorHelper.GetRandomColor());
                        graphics.DrawLine(pen, mp.X, mp.Y, simplePoint.X, simplePoint.Y);
                        graphics.DrawEllipse(new Pen(Color.Red, 5), simplePoint.X, simplePoint.Y, 1, 1);
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
