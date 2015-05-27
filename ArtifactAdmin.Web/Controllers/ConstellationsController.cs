// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstellationsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ConstellationsController type.
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

    public class ConstellationsController : Controller
    {
        private IConstellationService constellationService;

        public ConstellationsController(IConstellationService constellationService)
        {
            this.constellationService = constellationService;
        }

        // GET: Constellations
        public ActionResult Index()
        {
            return View(this.constellationService.GetAll());
        }

        // GET: Constellations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
           var constellation = this.constellationService.GetById(id);
           
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
        public ActionResult Create([Bind(Include = "id,Name,Icon,Description")] ConstellationDto constellation, HttpPostedFileBase Icon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                    try
                    {
                        this.constellationService.Create(constellation, Icon);
                    }
                    catch (Exception e)
                    {
                        ViewBag.Error = "Помилка при створенні нового запису";
                        ViewBag.ErrMes = e.Message;
                        return View(constellation);
                    }

                    this.constellationService.SaveIcon(constellation, Icon);
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

            var constellation = this.constellationService.GetById(id);
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
        public ActionResult Edit([Bind(Include = "id,Name,Icon,Description")] ConstellationDto constellation)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.constellationService.Update(constellation);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
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

            var constellation = this.constellationService.GetById(id);
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
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var constellation = this.constellationService.GetById(id);
            try
            {
                this.constellationService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(constellation);
            }

            return RedirectToAction("Index");
        }
    }
}
