// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArtifactTypesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ArtifactTypesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class ArtifactTypesController : Controller
    {
        private IArtifactTypeService artifactTypeService;

        public ArtifactTypesController(IArtifactTypeService artifactTypeService)
        {
            this.artifactTypeService = artifactTypeService;
        }

        // GET: ArtifactTypes
        public ActionResult Index()
        {
            return View(this.artifactTypeService.GetAll());
        }

        // GET: ArtifactTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var artifactType = this.artifactTypeService.GetById(id);

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
        public ActionResult Create([Bind(Include = "id,Name,Icon,Descrioption")] ArtifactTypeDto artifactType, HttpPostedFileBase Icon)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.artifactTypeService.Create(artifactType, Icon);
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

            var artifactType = this.artifactTypeService.GetById(id);
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
        public ActionResult Edit([Bind(Include = "id,Name,Icon,Descrioption")] ArtifactTypeDto artifactType)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.artifactTypeService.Update(artifactType);
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

            var artifactType = this.artifactTypeService.GetById(id);
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
            ViewBag.Error = string.Empty;
            var artifactType = this.artifactTypeService.GetById(id);
            try
            {
                this.artifactTypeService.Delete(id);
            }
            catch
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                return View(artifactType);
            }
            
            return RedirectToAction("Index");
        }
    }
}
