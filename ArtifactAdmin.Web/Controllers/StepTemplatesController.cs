// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepTemplatesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepTemplatesController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils;

namespace ArtifactAdmin.Web.Controllers
{
    public class StepTemplatesController : Controller
    {
        private IStepTemplateService stepTemplateService;

        public StepTemplatesController(IStepTemplateService stepTemplateService)
        {
            this.stepTemplateService = stepTemplateService;
        }
    
        // GET: StepTemplates
        public ActionResult Index()
        {
            return View(this.stepTemplateService.GetAll());
        }

        // GET: StepTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewStepTemplateDto = this.stepTemplateService.GetViewById(id);
            if (viewStepTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(viewStepTemplateDto);
        }

        // GET: StepTemplates/Create
       
        public ActionResult Create()
        {
            var viewStepTemplateDto = this.stepTemplateService.GetViewById(null);
            return View(viewStepTemplateDto);
        }
        
        // POST: StepTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,StepText,Name,Desire,IsNotVisibleInFlow,IsQuestStarter")] StepTemplateDto stepTemplate, string[] selectedStepObject)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewStepTemplateDto = new ViewStepTemplateDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.stepTemplateService.Create(stepTemplate, selectedStepObject);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    viewStepTemplateDto = this.stepTemplateService.GetViewById(stepTemplate.Id);
                    return View(viewStepTemplateDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при створенні нового запису";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            viewStepTemplateDto = this.stepTemplateService.GetViewById(stepTemplate.Id);
            return View(viewStepTemplateDto);
        }

        // GET: StepTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewStepTemplateDto = this.stepTemplateService.GetViewById(id);
            if (viewStepTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(viewStepTemplateDto);
        }

        // POST: StepTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,StepText,Name,Desire,IsNotVisibleInFlow,IsQuestStarter")] StepTemplateDto stepTemplate, string[] selectedStepObject)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewStepTemplateDto = new ViewStepTemplateDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.stepTemplateService.Update(stepTemplate, selectedStepObject);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    viewStepTemplateDto = this.stepTemplateService.GetViewById(stepTemplate.Id);
                    return View(viewStepTemplateDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при спробі змінити запис";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            viewStepTemplateDto = this.stepTemplateService.GetViewById(stepTemplate.Id);
            return View(viewStepTemplateDto);
        }

        // GET: StepTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stepTemplateDto = this.stepTemplateService.GetById(id);
            if (stepTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(stepTemplateDto);
        }

        // POST: StepTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var stepTemplateDto = this.stepTemplateService.GetById(id);
            try
            {
                this.stepTemplateService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(stepTemplateDto);
            }

            return RedirectToAction("Index");
        }
    }
}
