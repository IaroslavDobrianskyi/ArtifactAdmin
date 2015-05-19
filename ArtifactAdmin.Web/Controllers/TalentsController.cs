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
        public ActionResult Create([Bind(Include = "id,Description,Name,MaxLevel,Modifier,BaseValue,BaseModifier,Icon")]
            Talent talent, HttpPostedFileBase Icon)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(Icon.FileName);
                fileName = Guid.NewGuid().ToString() + '_' + fileName;
                string IPath = ArtifactAdmin.App_Start.ImagePath.ImPath;
                Directory.CreateDirectory(Server.MapPath(IPath + "Talents"));
                var path = Path.Combine(Server.MapPath(IPath + "Talents"), fileName);
                Icon.SaveAs(path);
                talent.Icon = fileName;
                try
                {
                    db.Talents.Add(talent);
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    return View(talent);
                }
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
        public ActionResult Edit([Bind(Include = "id,Description,Name,MaxLevel,Modifier,BaseValue,BaseModifier,Icon")] Talent talent)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(talent).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    return View(talent);
                }
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
            ViewBag.Error = string.Empty;
            Talent talent = db.Talents.Find(id);
            string fileName = talent.Icon;
            string IPath = ArtifactAdmin.App_Start.ImagePath.ImPath;
            var path = Path.Combine(Server.MapPath(IPath + "Talents"), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists) file.Delete();
            try
            {
                db.Talents.Remove(talent);
                db.SaveChanges();
            }
            catch 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                return View(talent);
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
