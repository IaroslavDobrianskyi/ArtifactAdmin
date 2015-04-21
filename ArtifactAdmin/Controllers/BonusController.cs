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
    public class BonusController : Controller
    {
        private artEntities db = new artEntities();

        // GET: Bonus
        public ActionResult Index()
        {
            return View(db.Bonus.ToList());
        }

        // GET: Bonus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonu bonu = db.Bonus.Find(id);
            if (bonu == null)
            {
                return HttpNotFound();
            }
            return View(bonu);
        }

        // GET: Bonus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bonus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Bonu bonu)
        {
            if (ModelState.IsValid)
            {
                db.Bonus.Add(bonu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bonu);
        }

        // GET: Bonus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonu bonu = db.Bonus.Find(id);
            if (bonu == null)
            {
                return HttpNotFound();
            }
            return View(bonu);
        }

        // POST: Bonus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Bonu bonu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bonu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bonu);
        }

        // GET: Bonus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonu bonu = db.Bonus.Find(id);
            if (bonu == null)
            {
                return HttpNotFound();
            }
            return View(bonu);
        }

        // POST: Bonus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bonu bonu = db.Bonus.Find(id);
            db.Bonus.Remove(bonu);
            db.SaveChanges();
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
