// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepActionTemplatesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepActionTemplatesController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class StepActionTemplatesController : Controller
    {
        private IStepActionTemplateService stepActionTemplateService;

        public StepActionTemplatesController(IStepActionTemplateService stepActionTemplateService) 
        {
            this.stepActionTemplateService = stepActionTemplateService;
        }

        // GET: StepActionTemplates
        public ActionResult Index()
        {
            return View(this.stepActionTemplateService.GetAll());
        }

        // GET: StepActionTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewStepActionTemplateDto = this.stepActionTemplateService.GetViewById(id);
            if (viewStepActionTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(viewStepActionTemplateDto);
        }

        // GET: StepActionTemplates/Create
        public ActionResult Create()
        {
            return View(this.stepActionTemplateService.GetViewById(null));
        }

        // POST: StepActionTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,StepText,Name")] StepTemplateDto stepTemplateDto, string[] selectedActionTemplate)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewStepActionTemplateDto = new ViewStepActionTemplateDto();
            if (ModelState.IsValid)
            {
                try 
                {
                    this.stepActionTemplateService.Create(stepTemplateDto, selectedActionTemplate);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    viewStepActionTemplateDto = this.stepActionTemplateService.GetViewById(stepTemplateDto.Id);
                    return View(viewStepActionTemplateDto);
                }

                return RedirectToAction("Index");
            }

            viewStepActionTemplateDto = this.stepActionTemplateService.GetViewById(stepTemplateDto.Id);
            return View(viewStepActionTemplateDto);
        }

        // GET: StepActionTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewStepActionTemplateDto = this.stepActionTemplateService.GetViewById(id);
            if (viewStepActionTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(viewStepActionTemplateDto);
        }

        // POST: StepActionTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,StepText,Name")] StepTemplateDto stepTemplateDto, string[] selectedActionTemplate)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewStepActionTemplateDto = new ViewStepActionTemplateDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.stepActionTemplateService.Update(stepTemplateDto, selectedActionTemplate);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    viewStepActionTemplateDto = this.stepActionTemplateService.GetViewById(stepTemplateDto.Id);
                    return View(viewStepActionTemplateDto);
                }

                return RedirectToAction("Index");
            }

            viewStepActionTemplateDto = this.stepActionTemplateService.GetViewById(stepTemplateDto.Id);
            return View(viewStepActionTemplateDto);
        }

        // GET: StepActionTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stepTemplateDto = this.stepActionTemplateService.GetById(id);
            if (stepTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(stepTemplateDto);
        }

        // POST: StepActionTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var stepTemplateDto = this.stepActionTemplateService.GetById(id);
            try
            {
                this.stepActionTemplateService.Delete(id);
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
