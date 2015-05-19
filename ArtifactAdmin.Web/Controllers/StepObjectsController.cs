// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectsController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using ArtifactAdmin.DAL;
    using BL.Interfaces;

    public class StepObjectsController : Controller
    {
        private IStepObjectService stepObjectService;

        public StepObjectsController(IStepObjectService stepObjectService)
        {
            this.stepObjectService = stepObjectService;
        }

        // GET: StepObjects
        public ActionResult Index()
        {
            return View(this.stepObjectService.GetAll());
        }

        // GET: StepObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var stepObject = this.stepObjectService.GetById(id);

            if (stepObject == null)
            {
                return HttpNotFound();
            }
            
            return View(stepObject);
        }

        // GET: StepObjects/Create
        public ActionResult Create()
        {
            ViewBag.StepObjectType = new SelectList(db.StepObjectTypes, "id", "Name");
            return View();
        }

        // POST: StepObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,StepObjectType,Name,Description,Icon")] StepObject stepObject, HttpPostedFileBase Icon)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(Icon.FileName);
                fileName = Guid.NewGuid().ToString() + '_' + fileName;

                string IPath = ArtifactAdmin.BL.App_Start.ImagePath.ImPath;
                Directory.CreateDirectory(Server.MapPath(IPath + "StepObjects"));
                var path = Path.Combine(Server.MapPath(IPath + "StepObjects"), fileName);
               
                Icon.SaveAs(path);
                stepObject.Icon = fileName;
                try
                {
                    db.StepObjects.Add(stepObject);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    ViewBag.StepObjectType = new SelectList(db.StepObjectTypes, "id", "Name", stepObject.StepObjectType);
                    return View(stepObject);
                }
                return RedirectToAction("Index");
            }

            ViewBag.StepObjectType = new SelectList(db.StepObjectTypes, "id", "Name", stepObject.StepObjectType);
            return View(stepObject);
        }

        // GET: StepObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepObject stepObject = db.StepObjects.Find(id);
            if (stepObject == null)
            {
                return HttpNotFound();
            }
            ViewBag.StepObjectType = new SelectList(db.StepObjectTypes, "id", "Name", stepObject.StepObjectType);
            return View(stepObject);
        }

        // POST: StepObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,StepObjectType,Name,Description,Icon")] StepObject stepObject)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(stepObject).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch 
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.StepObjectType = new SelectList(db.StepObjectTypes, "id", "Name", stepObject.StepObjectType);
                    return View(stepObject);
                }
                return RedirectToAction("Index");
            }
            ViewBag.StepObjectType = new SelectList(db.StepObjectTypes, "id", "Name", stepObject.StepObjectType);
            return View(stepObject);
        }

        // GET: StepObjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepObject stepObject = db.StepObjects.Find(id);
            if (stepObject == null)
            {
                return HttpNotFound();
            }
            return View(stepObject);
        }

        // POST: StepObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            StepObject stepObject = db.StepObjects.Find(id);
            try
            {
                db.StepObjects.Remove(stepObject);
                db.SaveChanges();
            }
            catch 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.StepObjectType = new SelectList(db.StepObjectTypes, "id", "Name", stepObject.StepObjectType);
                return View(stepObject);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
