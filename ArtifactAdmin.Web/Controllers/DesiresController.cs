// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesiresController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the DesiresController  type.
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

    public class DesiresController : Controller
    {
        private IDesireService desireService;
        
        public DesiresController(IDesireService desireService) 
        {
            this.desireService = desireService;
        }

        // GET: Desires
        public ActionResult Index()
        {
            return View(this.desireService.GetAll());
        }

        // GET: Desires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var desireDto = this.desireService.GetById(id);
            if (desireDto == null)
            {
                return HttpNotFound();
            }

            return View(desireDto);
        }

        // GET: Desires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Icon")] DesireDto desire, HttpPostedFileBase icon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var fileNameForSave = FileHelper.SaveIcon("Desires", icon);
                if (string.IsNullOrEmpty(fileNameForSave)) 
                {
                    ViewBag.Error = "Помилка при збереженні іконки";
                    return View(desire);
                }

                try 
                {
                    this.desireService.Create(desire, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(desire);
                }

                return RedirectToAction("Index");
            }

            return View(desire);
        }

        // GET: Desires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var desireDto = this.desireService.GetById(id);
            if (desireDto == null)
            {
                return HttpNotFound();
            }

            return View(desireDto);
        }

        // POST: Desires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Icon")] DesireDto desire, HttpPostedFileBase newIcon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var oldFileNAme = desire.Icon;
                var fileNameForSave = oldFileNAme;
                if (newIcon != null) 
                {
                    fileNameForSave = FileHelper.SaveIcon("Desires", newIcon);
                    if (string.IsNullOrEmpty(fileNameForSave)) 
                    {
                        ViewBag.Error = "Помилка при збереженні іконки";
                        return View(desire);
                    }
                }

                try
                {
                    this.desireService.Update(desire, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(desire);
                }

                if (oldFileNAme != fileNameForSave)
                {
                    FileHelper.DeleteIcon(oldFileNAme, "Desires");
                }

                return RedirectToAction("Index");
            }

            return View(desire);
        }

        // GET: Desires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var desireDto = this.desireService.GetById(id);
            if (desireDto == null)
            {
                return HttpNotFound();
            }

            return View(desireDto);
        }

        // POST: Desires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var desireDto = this.desireService.GetById(id);
            var fileName = desireDto.Icon;
            try
            {
                this.desireService.Delete(id);
            }
            catch (Exception e) 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(desireDto);
            }

            FileHelper.DeleteIcon(fileName, "Desires");
            return RedirectToAction("Index");
        }
        // GET: Desires/Modifier/5
        public ActionResult Modifier(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var desireDto = this.desireService.GetByIdMapZone(Convert.ToInt32(id));
            if (desireDto == null)
            {
                return HttpNotFound();
            }

            ViewBag.Name = "Бажання";
            ViewBag.ItemName = "MapZone1.ZoneName";
            ViewBag.SelectedItem = "Зони карти";
            return View("../Shared/ViewDesireMapZone", desireDto.ViewDesireMapZoneDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier([Bind(Include = "ItemId,ItemName")] ViewDesireMapZoneDto desire, int[] listDesireMapZone, double[] modifiers)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            ViewBag.Name = "Бажання";
            ViewBag.ItemName = "MapZone1.ZoneName";
            ViewBag.SelectedItem = "Зони карти";
            var desireDto = new DesireDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.desireService.UpdateDesireMapZone(desire.ItemId, listDesireMapZone, modifiers);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    desireDto = this.desireService.GetByIdMapZone(desire.ItemId);
                    return View("../Shared/ViewDesireMapZone", desireDto.ViewDesireMapZoneDto);
                }

                return RedirectToAction("Index");
            }

            desireDto = this.desireService.GetByIdMapZone(desire.ItemId);
            return View("../Shared/ViewDesireMapZone", desireDto.ViewDesireMapZoneDto);
        }
    }
}
