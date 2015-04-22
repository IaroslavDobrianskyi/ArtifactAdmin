using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtifactAdmin.Models;
using System.IO;

namespace ArtifactAdmin.Controllers
{
    public class ArtifactTypesController : Controller
    {
        private artEntities db = new artEntities();

        // GET: ArtifactTypes
        public ActionResult Index()
        {
            return View(db.ArtifactTypes.ToList());
        }

        // GET: ArtifactTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtifactType artifactType = db.ArtifactTypes.Find(id);
            if (artifactType == null)
            {
                return HttpNotFound();
            }
            return View(artifactType);
        }

        // GET: ArtifactTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtifactTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Icon,Descrioption")] ArtifactType artifactType, HttpPostedFileBase Icon)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(Icon.FileName);
                fileName = Guid.NewGuid().ToString() + '_' + fileName;
                string IPath = ArtifactAdmin.App_Start.ImagePath.ImPath;
                var path = Path.Combine(Server.MapPath(IPath+"ArtifactTypes"), fileName);
                Icon.SaveAs(path);
                artifactType.Icon = fileName;
                try
                {
                    db.ArtifactTypes.Add(artifactType);
                    db.SaveChanges();
                }
                catch
                {
                     ViewBag.Error = "Помилка при створенні нового запису";
                     return View(artifactType);
                }
                return RedirectToAction("Index");
            }

            return View(artifactType);
        }

        // GET: ArtifactTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtifactType artifactType = db.ArtifactTypes.Find(id);
            if (artifactType == null)
            {
                return HttpNotFound();
            }
            return View(artifactType);
        }

        // POST: ArtifactTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Icon,Descrioption")] ArtifactType artifactType)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(artifactType).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    return View(artifactType);
                }
                return RedirectToAction("Index");
            }
            return View(artifactType);
        }

        // GET: ArtifactTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtifactType artifactType = db.ArtifactTypes.Find(id);
            if (artifactType == null)
            {
                return HttpNotFound();
            }
            return View(artifactType);
        }

        // POST: ArtifactTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = "";
            ArtifactType artifactType = db.ArtifactTypes.Find(id);
            string fileName = artifactType.Icon;
            string IPath = ArtifactAdmin.App_Start.ImagePath.ImPath;
            var path = Path.Combine(Server.MapPath(IPath + "ArtifactTypes"), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists) file.Delete();
            try
            {
                db.ArtifactTypes.Remove(artifactType);
                db.SaveChanges();
            }
            catch 
            {
                 ViewBag.Error = "Помилка при видаленні запису !";
                return View(artifactType);
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
