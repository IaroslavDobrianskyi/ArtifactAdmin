// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapZonesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapZonesController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;
    public class MapZonesController : Controller
    {
        private IMapZoneService mapZoneService;
        public MapZonesController(IMapZoneService mapZoneService) 
        {
            this.mapZoneService = mapZoneService;
        }

        // GET: MapZones
        public ActionResult Index()
        {
            return View(this.mapZoneService.GetAll());
        }

        // GET: MapZones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewMapZoneDto = this.mapZoneService.GetViewById(id);
            if (viewMapZoneDto == null)
            {
                return HttpNotFound();
            }
            return View(viewMapZoneDto);
        }

        // GET: MapZones/Create
        public ActionResult Create()
        {
            var viewMapZoneDto = this.mapZoneService.GetViewById(null);
            return View(viewMapZoneDto);
        }

        // POST: MapZones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ZoneName,Color")] MapZoneDto mapZone, string[] SelectedMapObject, string[] Probability)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewMapZoneDto = new ViewMapZoneDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapZoneService.Create(mapZone, SelectedMapObject, Probability);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    viewMapZoneDto = this.mapZoneService.GetViewById(mapZone.id);
                    return View(viewMapZoneDto);
                }

                return RedirectToAction("Index");
            }

            viewMapZoneDto = this.mapZoneService.GetViewById(mapZone.id);
            return View(viewMapZoneDto);
        }

        // GET: MapZones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewMapZoneDto = this.mapZoneService.GetViewById(id);
            if (viewMapZoneDto == null)
            {
                return HttpNotFound();
            }
            return View(viewMapZoneDto);
        }

        // POST: MapZones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ZoneName,Color")] MapZoneDto mapZone, string[] SelectedMapObject, string[] Probability)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewMapZoneDto = new ViewMapZoneDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapZoneService.Update(mapZone, SelectedMapObject, Probability);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    viewMapZoneDto = this.mapZoneService.GetViewById(mapZone.id);
                    return View(viewMapZoneDto);
                }

                return RedirectToAction("Index");
            }

            viewMapZoneDto = this.mapZoneService.GetViewById(mapZone.id);
            return View(viewMapZoneDto);
        }

        // GET: MapZones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewMapZoneDto = this.mapZoneService.GetViewById(id);
            if (viewMapZoneDto == null)
            {
                return HttpNotFound();
            }
            return View(viewMapZoneDto);
        }

        // POST: MapZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewmapZoneDto = this.mapZoneService.GetViewById(id);
            try 
            {
                this.mapZoneService.Delete(id);
            }
            catch (Exception e) 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(viewmapZoneDto);
            }

            return RedirectToAction("Index");
        }
    }
}
