// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BonusController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the BonusController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class BonusController : Controller
    {
        private IBonusService bonusService;

        public BonusController(IBonusService bonusService)
        {
            this.bonusService = bonusService;
        }
        // GET: Bonus
        public ActionResult Index()
        {
            return View(this.bonusService.GetAll());
        }

        // GET: Bonus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bonu = this.bonusService.GetById(id);
                
            if (bonu == null)
            {
                return this.HttpNotFound();
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
        public ActionResult Create([Bind(Include = "Id,Name,Description")] BonusDto bonu)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.bonusService.Create(bonu);
                }
                catch  
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    return View(bonu);
                }

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

            var bonu = this.bonusService.GetById(id);
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
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] BonusDto bonu)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.bonusService.Update(bonu);
                }
                catch
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    return View(bonu);
                }

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

            var bonu = this.bonusService.GetById(id);
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
            ViewBag.Error = string.Empty;
            var bonu = this.bonusService.GetById(id);
            try
            { 
            this.bonusService.Delete(id);
            }
            catch
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                return View(bonu);
            }

            return RedirectToAction("Index");
        }
        }
}
