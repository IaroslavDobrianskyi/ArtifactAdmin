// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectTypesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectTypesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using ArtifactAdmin.DAL;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class StepObjectTypesController : Controller
    {
        private IStepObjectTypeService stepObjectTypeService;

        public StepObjectTypesController(IStepObjectTypeService stepObjectTypeService)
        {
            this.stepObjectTypeService = stepObjectTypeService;
        }

        // GET: StepObjectTypes
        public ActionResult Index()
        {
            return View(this.stepObjectTypeService.GetAll());
        }

        // GET: StepObjectTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var stepObjectType = this.stepObjectTypeService.GetById(id);
            if (stepObjectType == null)
            {
                return HttpNotFound();
            }
            
            return View(stepObjectType);
        }

        // GET: StepObjectTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StepObjectTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] StepObjectTypeDto stepObjectType)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.stepObjectTypeService.Create(stepObjectType);
                }
                catch 
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    return View(stepObjectType);
                }

                return RedirectToAction("Index");
            }

            return View(stepObjectType);
        }

        // GET: StepObjectTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stepObjectType = this.stepObjectTypeService.GetById(id);
            if (stepObjectType == null)
            {
                return HttpNotFound();
            }

            return View(stepObjectType);
        }

        // POST: StepObjectTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] StepObjectTypeDto stepObjectType)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.stepObjectTypeService.Update(stepObjectType);
                }
                catch
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    return View(stepObjectType);
                }

                return RedirectToAction("Index");
            }

            return View(stepObjectType);
        }

        // GET: StepObjectTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stepObjectType = this.stepObjectTypeService.GetById(id);
            if (stepObjectType == null)
            {
                return HttpNotFound();
            }

            return View(stepObjectType);
        }

        // POST: StepObjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            var stepObjectType = this.stepObjectTypeService.GetById(id);
            try
            {
                this.stepObjectTypeService.Delete(id);
            }
            catch 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                return View(stepObjectType);
            }

            return RedirectToAction("Index");
        }
    }
}
