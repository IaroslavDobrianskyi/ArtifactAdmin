// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectTypesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectTypesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Controllers
{
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
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.stepObjectTypeService.Create(stepObjectType);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
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
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.stepObjectTypeService.Update(stepObjectType);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
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
            ViewBag.ErrMes = string.Empty;
            var stepObjectType = this.stepObjectTypeService.GetById(id);
            try
            {
                this.stepObjectTypeService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(stepObjectType);
            }

            return RedirectToAction("Index");
        }
    }
}
