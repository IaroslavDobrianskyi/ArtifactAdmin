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
    public class TalentsController : Controller
    {
        private artEntities db = new artEntities();

        // GET: Talents
        public ActionResult Index()
        {
            return View(db.Talents.ToList());
        }

        // GET: Talents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talent talent = db.Talents.Find(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }

        // GET: Talents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Description,Name,MaxLevel,Modifier,BaseValue,BaseModifier")] Talent talent)
        {
            if (ModelState.IsValid)
            {
                db.Talents.Add(talent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talent);
        }

        // GET: Talents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talent talent = db.Talents.Find(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }

        // POST: Talents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Description,Name,MaxLevel,Modifier,BaseValue,BaseModifier")] Talent talent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talent);
        }

        // GET: Talents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talent talent = db.Talents.Find(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }

        // POST: Talents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talent talent = db.Talents.Find(id);
            db.Talents.Remove(talent);
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
