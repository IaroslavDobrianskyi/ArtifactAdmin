// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateResultsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateResultsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class ActionTemplateResultsController : Controller
    {
        private IActionTemplateResultService actionTemplateResultService;

        public ActionTemplateResultsController(IActionTemplateResultService actionTemplateResultService) 
        {
            this.actionTemplateResultService = actionTemplateResultService;
        }

        // GET: ActionTemplateResults
        public ActionResult Index()
        {
            return View(this.actionTemplateResultService.GetAll());
        }

        // GET: ActionTemplateResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actionTemplateResult = this.actionTemplateResultService.GetById(id);
            if (actionTemplateResult == null)
            {
                return HttpNotFound();
            }

            return View(actionTemplateResult);
        }

        // GET: ActionTemplateResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActionTemplateResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,PredispositionResultModifier,ExperienceModifier,ArtifactPosibility,GoldModifier")] ActionTemplateResultDto actionTemplateResultDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.actionTemplateResultService.Create(actionTemplateResultDto);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(actionTemplateResultDto);
                }

                return RedirectToAction("Index");
            }

            return View(actionTemplateResultDto);
        }

        // GET: ActionTemplateResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actionTemplateResult = this.actionTemplateResultService.GetById(id);
            if (actionTemplateResult == null)
            {
                return HttpNotFound();
            }

            return View(actionTemplateResult);
        }

        // POST: ActionTemplateResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,PredispositionResultModifier,ExperienceModifier,ArtifactPosibility,GoldModifier")] ActionTemplateResultDto actionTemplateResultDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.actionTemplateResultService.Update(actionTemplateResultDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(actionTemplateResultDto);
                }

                return RedirectToAction("Index");
            }

            return View(actionTemplateResultDto);
        }

        // GET: ActionTemplateResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actionTemplateResult = this.actionTemplateResultService.GetById(id);
            if (actionTemplateResult == null)
            {
                return HttpNotFound();
            }

            return View(actionTemplateResult);
        }

        // POST: ActionTemplateResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var actionTemplateResult = this.actionTemplateResultService.GetById(id);
            try
            {
                this.actionTemplateResultService.Delete(id);
            }
            catch (Exception e) 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(actionTemplateResult);
            }

            return RedirectToAction("Index");
        }
    }
}
