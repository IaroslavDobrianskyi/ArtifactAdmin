// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RacesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RacesController type.
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

    public class RacesController : Controller
    {
        private IRaceService raceService;

        public RacesController(IRaceService raceService) 
        {
            this.raceService = raceService;
        }

        // GET: Races
        public ActionResult Index()
        {
            return View(this.raceService.GetAll());
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var race = this.raceService.GetById(id);
            if (race == null)
            {
                return HttpNotFound();
            }

            return View(race);
        }

        // GET: Races/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,Id,Characreristics,CharacteristicsLevelModifier,Predisposition,Properties,Icon")] RaceDto race, HttpPostedFileBase icon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var fileNameForSave = FileHelper.SaveIcon("Races", icon);
                if (string.IsNullOrEmpty(fileNameForSave))
                {
                    ViewBag.Error = "Помилка при збереженні іконки";
                    return View(race);
                }

                try
                {
                    this.raceService.Create(race, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(race);
                }

                return RedirectToAction("Index");
            }

            return View(race);
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var race = this.raceService.GetById(id);
            if (race == null)
            {
                return HttpNotFound();
            }

            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Description,Id,Characreristics,CharacteristicsLevelModifier,Predisposition,Properties,Icon")] RaceDto race, HttpPostedFileBase newIcon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var oldfileName = race.Icon;
                var fileNameForSave = oldfileName;
                if (newIcon != null)
                {
                    fileNameForSave = FileHelper.SaveIcon("Races", newIcon);
                    if (string.IsNullOrEmpty(fileNameForSave))
                    {
                        ViewBag.Error = "Помилка при збереженні іконки";
                        return View(race);
                    }
                }

                try 
                {
                    this.raceService.Update(race, fileNameForSave);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(race);
                }

                if (oldfileName != fileNameForSave)
                {
                    FileHelper.DeleteIcon(oldfileName, "Races");
                }

                return RedirectToAction("Index");
            }

            return View(race);
        }

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var race = this.raceService.GetById(id);
            if (race == null)
            {
                return HttpNotFound();
            }

            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var race = this.raceService.GetById(id);
            var fileName = race.Icon;
            try 
            {
                this.raceService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(race);
            }

            FileHelper.DeleteIcon(fileName, "Races");
            return RedirectToAction("Index");
        }
    }
}
