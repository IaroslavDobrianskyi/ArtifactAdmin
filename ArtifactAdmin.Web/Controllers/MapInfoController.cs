using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils;

namespace ArtifactAdmin.Web.Controllers
{
    public class MapInfoController : Controller
    {
        private IMapInfoService mapInfoService;

        public MapInfoController(IMapInfoService mapInfoService) 
        {
            this.mapInfoService = mapInfoService;
        }

        public ActionResult Index()
        {
            return View(this.mapInfoService.GetAll());
        }

        // GET: MapInfo/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: MapInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MapName,ImagePath,Width,Height")] MapInfoDto mapInfo)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapInfoService.Create(mapInfo);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(mapInfo);
                }

                return RedirectToAction("Index");
            }

            return View(mapInfo);
        }

        // GET: MapInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mapObject = this.mapInfoService.GetById(id);
            if (mapObject == null)
            {
                return HttpNotFound();
            }

            return View(mapObject);
        }

        // POST: MapInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MapName,ImagePath,Width,Height")] MapInfoDto mapInfo)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapInfoService.Update(mapInfo);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(mapInfo);
                }

                return RedirectToAction("Index");
            }

            return View(mapInfo);
        }

        // GET: MapInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mapObject = this.mapInfoService.GetById(id);
            if (mapObject == null)
            {
                return HttpNotFound();
            }

            return View(mapObject);
        }

        // POST: MapInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var mapObject = this.mapInfoService.GetById(id);
            try
            {
                this.mapInfoService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(mapObject);
            }

            return RedirectToAction("Index");
        }

        // GET: MapInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mapObject = this.mapInfoService.GetById(id);
            if (mapObject == null)
            {
                return HttpNotFound();
            }

            return View(mapObject);
        }



        public ActionResult ImageFromFileOnServer(int? id)
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
            try
            {
                var image = Image.FromFile(mapInfo.ImagePath);
                return base.File(image.ToStream(ImageFormat.Bmp), "image/jpeg");
            }
            catch (Exception e)
            {
                return new EmptyResult();
            }            
        }
    }
}