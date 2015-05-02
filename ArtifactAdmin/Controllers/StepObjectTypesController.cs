using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtifactAdmin.Models;

namespace ArtifactAdmin.Controllers
{
    public class StepObjectTypesController : Controller
    {
        private artEntities db = new artEntities();

        // GET: StepObjectTypes
        public ActionResult Index()
        {
            return View(db.StepObjectTypes.ToList());
        }

        // GET: StepObjectTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepObjectType stepObjectType = db.StepObjectTypes.Find(id);
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
        public ActionResult Create([Bind(Include = "id,Name")] StepObjectType stepObjectType)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                try
                {
                    db.StepObjectTypes.Add(stepObjectType);
                    db.SaveChanges();
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
            StepObjectType stepObjectType = db.StepObjectTypes.Find(id);
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
        public ActionResult Edit([Bind(Include = "id,Name")] StepObjectType stepObjectType)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(stepObjectType).State = EntityState.Modified;
                    db.SaveChanges();
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
            StepObjectType stepObjectType = db.StepObjectTypes.Find(id);
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
            ViewBag.Error = "";
            StepObjectType stepObjectType = db.StepObjectTypes.Find(id);
            try
            {
                db.StepObjectTypes.Remove(stepObjectType);
                db.SaveChanges();
            }
            catch 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                return View(stepObjectType);
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
