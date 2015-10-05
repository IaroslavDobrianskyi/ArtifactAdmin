// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ClassesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Controllers
{
    public class ClassesController : Controller
    {
        private IClassService classService;

        public ClassesController(IClassService classService) 
        {
            this.classService = classService;
        }

        // GET: Classes
        public ActionResult Index()
        {
            return View(this.classService.GetAll());
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clas = this.classService.GetById(id);
            if (clas == null)
            {
                return HttpNotFound();
            }

            return View(clas);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Icon,FibonacciSeed")] ClassDto clas, HttpPostedFileBase icon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var fileNameForSave = FileHelper.SaveIcon("Classes", icon);
                if (string.IsNullOrEmpty(fileNameForSave))
                {
                    ViewBag.Error = "Помилка при збереженні іконки";
                    return View(clas);
                }

                try
                {
                    this.classService.Create(clas, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(clas);
                }

                return RedirectToAction("Index");
            }

            return View(clas);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clas = this.classService.GetById(id);
            if (clas == null)
            {
                return HttpNotFound();
            }

            return View(clas);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Icon,FibonacciSeed")] ClassDto clas, HttpPostedFileBase newIcon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var oldfileName = clas.Icon;
                var fileNameForSave = oldfileName;
                if (newIcon != null)
                {
                    fileNameForSave = FileHelper.SaveIcon("Classes", newIcon);
                    if (string.IsNullOrEmpty(fileNameForSave))
                    {
                        ViewBag.Error = "Помилка при збереженні іконки";
                        return View(clas);
                    }
                }

                try 
                {
                    this.classService.Update(clas, fileNameForSave);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(clas);
                }

                if (oldfileName != fileNameForSave)
                {
                    FileHelper.DeleteIcon(oldfileName, "Classes");
                }

                return RedirectToAction("Index");
            }

            return View(clas);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clas = this.classService.GetById(id);
            if (clas == null)
            {
                return HttpNotFound();
            }

            return View(clas);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var clas = this.classService.GetById(id);
            var fileName = clas.Icon;
            try 
            {
                this.classService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(clas);
            }

            FileHelper.DeleteIcon(fileName, "Classes");
            return RedirectToAction("Index");
        }
    }
}
