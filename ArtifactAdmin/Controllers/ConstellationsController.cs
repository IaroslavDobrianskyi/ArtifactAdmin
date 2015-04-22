using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using System.Web.Configuration;
using ArtifactAdmin.Models;
using System.IO;

namespace ArtifactAdmin.Controllers
{
    public class ConstellationsController : Controller
    {
        private artEntities db = new artEntities();

        // GET: Constellations
        public ActionResult Index()
        {
            return View(db.Constellations.ToList());
        }

        // GET: Constellations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            Constellation constellation = db.Constellations.Find(id);
           
            if (constellation == null)
            {
                return HttpNotFound();
            }
            return View(constellation);
        }

        // GET: Constellations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Constellations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Icon,Description")] Constellation constellation,HttpPostedFileBase Icon)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(Icon.FileName);
                fileName = Guid.NewGuid().ToString() + '_' + fileName;

                string IPath = ArtifactAdmin.App_Start.ImagePath.ImPath;

                var path = Path.Combine(Server.MapPath(IPath+"Constellations"), fileName);
                Icon.SaveAs(path);
                constellation.Icon = fileName;
                    try
                    {
                        db.Constellations.Add(constellation);
                        db.SaveChanges();
                       
                    }
                    catch
                    {
                        ViewBag.Error = "Помилка при створенні нового запису";
                        return View(constellation);
                    }

                    return RedirectToAction("Index");
            }

            return View(constellation);
        }

        // GET: Constellations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Constellation constellation = db.Constellations.Find(id);
            if (constellation == null)
            {
                return HttpNotFound();
            }
            return View(constellation);
        }

        // POST: Constellations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Icon,Description")] Constellation constellation)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(constellation).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    return View(constellation);
                }
                return RedirectToAction("Index");
            }
            return View(constellation);
        }

        // GET: Constellations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Constellation constellation = db.Constellations.Find(id);
            if (constellation == null)
            {
                return HttpNotFound();
            }
            return View(constellation);
        }

        // POST: Constellations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = "";
            Constellation constellation = db.Constellations.Find(id);
            string fileName = constellation.Icon;
            string IPath = ArtifactAdmin.App_Start.ImagePath.ImPath;
            var path = Path.Combine(Server.MapPath(IPath + "Constellations"), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists) file.Delete();
            try
            {
                db.Constellations.Remove(constellation);
                db.SaveChanges();

            }
            catch 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                return View(constellation);
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
