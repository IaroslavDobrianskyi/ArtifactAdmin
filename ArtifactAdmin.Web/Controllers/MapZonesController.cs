// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapZonesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapZonesController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils;

namespace ArtifactAdmin.Web.Controllers
{
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
        public ActionResult Create([Bind(Include = "Id,ZoneName,Color")] MapZoneDto mapZone, string[] selectedMapObject, string[] probability)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewMapZoneDto = new ViewMapZoneDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapZoneService.Create(mapZone, selectedMapObject, probability);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    viewMapZoneDto = this.mapZoneService.GetByList(mapZone, selectedMapObject, probability);
                    return View(viewMapZoneDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при спробі змінити запис";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            viewMapZoneDto = this.mapZoneService.GetByList(mapZone, selectedMapObject, probability);
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
        public ActionResult Edit([Bind(Include = "Id,ZoneName,Color")] MapZoneDto mapZone, string[] selectedMapObject, string[] probability)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewMapZoneDto = new ViewMapZoneDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapZoneService.Update(mapZone, selectedMapObject, probability);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    viewMapZoneDto = this.mapZoneService.GetByList(mapZone, selectedMapObject, probability);
                    return View(viewMapZoneDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при спробі змінити запис";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            viewMapZoneDto = this.mapZoneService.GetByList(mapZone, selectedMapObject, probability);
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
        // GET: Desires/Modifier/5
        public ActionResult Modifier(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var desireDto = this.mapZoneService.GetByIdDesire(Convert.ToInt32(id));
            if (desireDto == null)
            {
                return HttpNotFound();
            }

            ViewBag.Name = "Зона карти";
            ViewBag.ItemName = "Desire1.Name";
            ViewBag.SelectedItem = "Бажання";
            return View("../Shared/ViewDesireMapZone", desireDto.ViewDesireMapZoneDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier([Bind(Include = "ItemId,ItemName")] ViewDesireMapZoneDto desire, int[] listDesireMapZone, string[] modifiers)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            ViewBag.Name = "Зона карти";
            ViewBag.ItemName = "Desire1.Name";
            ViewBag.SelectedItem = "Бажання";
            var desireDto = new MapZoneDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.mapZoneService.UpdateDesireMapZone(desire.ItemId, listDesireMapZone, modifiers);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    desireDto = this.mapZoneService.GetByIdDesire(desire.ItemId);
                    return View("../Shared/ViewDesireMapZone", desireDto.ViewDesireMapZoneDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при спробі змінити запис";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            desireDto = this.mapZoneService.GetByIdDesire(desire.ItemId);
            return View("../Shared/ViewDesireMapZone", desireDto.ViewDesireMapZoneDto);
        }
    }
}
