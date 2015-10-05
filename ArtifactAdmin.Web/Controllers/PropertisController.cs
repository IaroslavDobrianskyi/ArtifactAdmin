// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertisController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the PropertisController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Controllers
{
    public class PropertisController : Controller
    {
        private IPropertyService propertyService;

        public PropertisController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        // GET: Properties
        public ActionResult Index()
        {
            return View(this.propertyService.GetAll());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var propertyDto = this.propertyService.GetById(id);
            if (propertyDto == null)
            {
                return HttpNotFound();
            }

            return View(propertyDto);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Length,Position,Deviation")] PropertyDto propertyDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.propertyService.Create(propertyDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return this.View(propertyDto);
                }

                return RedirectToAction("Index");
            }

            return View(propertyDto);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var propertyDto = this.propertyService.GetById(id);
            if (propertyDto == null)
            {
                return HttpNotFound();
            }

            return View(propertyDto);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Length,Position,Deviation")] PropertyDto propertyDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.propertyService.Update(propertyDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return this.View(propertyDto);
                }

                return RedirectToAction("Index");
            }

            return View(propertyDto);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var propertyDto = this.propertyService.GetById(id);
            if (propertyDto == null)
            {
                return HttpNotFound();
            }

            return View(propertyDto);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var propertyDto = this.propertyService.GetById(id);
            try
            {
                this.propertyService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(propertyDto);
            }

            return RedirectToAction("Index");
        }
    }
}
