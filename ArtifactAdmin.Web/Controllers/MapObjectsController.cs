// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapObjectsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapObjectsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class MapObjectsController : Controller
    {
        private IMapObjectService mapObjectService;

        public MapObjectsController(IMapObjectService mapObjectService) 
        {
            this.mapObjectService = mapObjectService;
        }

        // GET: MapObjects
        public ActionResult Index()
        {
            return View(this.mapObjectService.GetAll());
        }

        // GET: MapObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mapObject = this.mapObjectService.GetById(id);
            if (mapObject == null)
            {
                return HttpNotFound();
            }

            return View(mapObject);
        }

        // GET: MapObjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MapObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name")] MapObjectDto mapObject)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapObjectService.Create(mapObject);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(mapObject);
                }

                return RedirectToAction("Index");
            }

            return View(mapObject);
        }

        // GET: MapObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mapObject = this.mapObjectService.GetById(id);
            if (mapObject == null)
            {
                return HttpNotFound();
            }

            return View(mapObject);
        }

        // POST: MapObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] MapObjectDto mapObject)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapObjectService.Update(mapObject);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(mapObject);
                }

                return RedirectToAction("Index");
            }

            return View(mapObject);
        }

        // GET: MapObjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mapObject = this.mapObjectService.GetById(id);
            if (mapObject == null)
            {
                return HttpNotFound();
            }

            return View(mapObject);
        }

        // POST: MapObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var mapObject = this.mapObjectService.GetById(id);
            try
            {
                this.mapObjectService.Delete(id);
            }
            catch (Exception e) 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(mapObject);
            }

            return RedirectToAction("Index");
        }
    }
}
