// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PredispositionsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the PredispositionsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Controllers
{
    public class PredispositionsController : Controller
    {
        private IPredispositionService predispositionService;

        public PredispositionsController(IPredispositionService predispositionService)
        {
            this.predispositionService = predispositionService;
        }

        // GET: Predispositions
        public ActionResult Index()
        {
            return View(this.predispositionService.GetAll());
        }

        // GET: Predispositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var predispositionDto = this.predispositionService.GetById(id);
            if (predispositionDto == null)
            {
                return HttpNotFound();
            }

            return View(predispositionDto);
        }

        // GET: Predispositions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predispositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Mask,Length,Position")] PredispositionDto predispositionDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.predispositionService.Create(predispositionDto);
                }
                catch (Exception e)
                {
                     ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return this.View(predispositionDto);
                }
           
                return RedirectToAction("Index");
            }

            return View(predispositionDto);
        }

        // GET: Predispositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var predispositionDto = this.predispositionService.GetById(id);
            if (predispositionDto == null)
            {
                return HttpNotFound();
            }

            return View(predispositionDto);
        }

        // POST: Predispositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Mask,Length,Position")] PredispositionDto predispositionDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.predispositionService.Update(predispositionDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(predispositionDto);
                }

                return RedirectToAction("Index");
            }

            return View(predispositionDto);
        }

        // GET: Predispositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var predispositionDto = this.predispositionService.GetById(id);
            if (predispositionDto == null)
            {
                return HttpNotFound();
            }

            return View(predispositionDto);
        }

        // POST: Predispositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var predispositionDto = this.predispositionService.GetById(id);
            try
            {
                this.predispositionService.Delete(id);
            }
            catch (Exception e)
            {
                 ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(predispositionDto);
            }

            return RedirectToAction("Index");
        }
    }
}
