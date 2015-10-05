// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateResultsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateResultsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Controllers
{
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
            return View(this.actionTemplateResultService.GetViewById(null));
        }

        // POST: ActionTemplateResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PredispositionResultModifier,ExperienceModifier,ArtifactPosibility,GoldModifier,QuestTemplate")] ActionTemplateResultDto actionTemplateResultDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewActionTemplateResult = this.actionTemplateResultService.GetViewById(null);
            viewActionTemplateResult.PredispositionResultModifier = actionTemplateResultDto.PredispositionResultModifier;
            viewActionTemplateResult.ExperienceModifier = actionTemplateResultDto.ExperienceModifier;
            viewActionTemplateResult.ArtifactPosibility = actionTemplateResultDto.ArtifactPosibility;
            viewActionTemplateResult.GoldModifier = actionTemplateResultDto.GoldModifier;
            viewActionTemplateResult.QuestTemplate = actionTemplateResultDto.QuestTemplate;
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
                    return View(viewActionTemplateResult);
                }

                return RedirectToAction("Index");
            }

            return View(viewActionTemplateResult);
        }

        // GET: ActionTemplateResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actionTemplateResult = this.actionTemplateResultService.GetViewById(id);
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
        public ActionResult Edit([Bind(Include = "Id,PredispositionResultModifier,ExperienceModifier,ArtifactPosibility,GoldModifier,QuestTemplate")] ActionTemplateResultDto actionTemplateResultDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewActionTemplateResult = this.actionTemplateResultService.GetViewById(null);
            viewActionTemplateResult.PredispositionResultModifier = actionTemplateResultDto.PredispositionResultModifier;
            viewActionTemplateResult.ExperienceModifier = actionTemplateResultDto.ExperienceModifier;
            viewActionTemplateResult.ArtifactPosibility = actionTemplateResultDto.ArtifactPosibility;
            viewActionTemplateResult.GoldModifier = actionTemplateResultDto.GoldModifier;
            viewActionTemplateResult.QuestTemplate = actionTemplateResultDto.QuestTemplate;
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
                    return View(viewActionTemplateResult);
                }

                return RedirectToAction("Index");
            }

            return View(viewActionTemplateResult);
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
