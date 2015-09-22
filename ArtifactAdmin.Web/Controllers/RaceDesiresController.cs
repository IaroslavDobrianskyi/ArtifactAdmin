// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaceDesiresController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RaceDesiresController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.Utils;

    public class RaceDesiresController : Controller
    {
        private IRaceDesireService raceDesireService;

        public RaceDesiresController(IRaceDesireService raceDesireService)
        {
            this.raceDesireService = raceDesireService;
        }

        // GET: RaceDesires
        public ActionResult Index()
        {
            return View(this.raceDesireService.GetAll());
        }

        // GET: RaceDesires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewRaceDesireDto = this.raceDesireService.GetViewById(id);
            if (viewRaceDesireDto == null)
            {
                return HttpNotFound();
            }

            return View(viewRaceDesireDto);
        }

        // GET: RaceDesires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewRaceDesireDto = this.raceDesireService.GetViewById(id);
            if (viewRaceDesireDto == null)
            {
                return HttpNotFound();
            }

            return View(viewRaceDesireDto);
        }

        // POST: RaceDesires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int[] selectedDesires, string[] probabilities, int[] defaultValues, string[] deviations)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewRaceDesireDto = this.raceDesireService.GetViewById(id);
            if (ModelState.IsValid)
            {
                try
                {
                    this.raceDesireService.Update(id, selectedDesires, probabilities, defaultValues, deviations);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    
                    return View(viewRaceDesireDto);
                }
               
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при спробі змінити запис";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            viewRaceDesireDto = this.raceDesireService.GetViewById(id);
            return View(viewRaceDesireDto);
        }

        // GET: RaceDesires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewRaceDesireDto = this.raceDesireService.GetViewById(id);
            if (viewRaceDesireDto == null)
            {
                return HttpNotFound();
            }

            return View(viewRaceDesireDto);
        }

        // POST: RaceDesires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewRaceDesireDto = this.raceDesireService.GetViewById(id);
            try
            {
               this.raceDesireService.Delete(id); 
            }
            catch (Exception e)
            {
               ViewBag.Error = "Помилка при видаленні запису !";
               ViewBag.ErrMes = e.Message;
               return View(viewRaceDesireDto);
            }

            return RedirectToAction("Index");
        }
    }
}
