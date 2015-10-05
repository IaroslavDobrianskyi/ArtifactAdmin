// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestTemplatesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the QuestTemplatesController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;
    using BL.Utils;

    public class QuestTemplatesController : Controller
    {
        private IQuestTemplateService questTemplateService;

        public QuestTemplatesController(IQuestTemplateService questTemplateService)
        {
            this.questTemplateService = questTemplateService;
        }

        // GET: QuestTemplates
        public ActionResult Index()
        {
            return View(this.questTemplateService.GetAll());
        }

        // GET: QuestTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var questTemplate = this.questTemplateService.GetViewById(id);
            if (questTemplate == null)
            {
                return HttpNotFound();
            }

            return View(questTemplate);
        }

        // GET: QuestTemplates/Create
        public ActionResult Create()
        {
            return View(this.questTemplateService.GetViewById(null));
        }

        // POST: QuestTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] QuestTemplateDto questTemplateDto, string[] selectedSteps)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.questTemplateService.Create(questTemplateDto, selectedSteps);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    questTemplateDto = this.questTemplateService.GetByList(questTemplateDto, selectedSteps);
                    return View(questTemplateDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при створенні нового запису";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            questTemplateDto = this.questTemplateService.GetByList(questTemplateDto, selectedSteps); 
            return View(questTemplateDto);
        }

        // GET: QuestTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var questTemplateDto = this.questTemplateService.GetViewById(id);
            if (questTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(questTemplateDto);
        }

        // POST: QuestTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] QuestTemplateDto questTemplateDto, string[] selectedSteps)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.questTemplateService.Update(questTemplateDto, selectedSteps);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    questTemplateDto = this.questTemplateService.GetByList(questTemplateDto, selectedSteps);
                    return View(questTemplateDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при спробі змінити запис";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            questTemplateDto = this.questTemplateService.GetByList(questTemplateDto, selectedSteps);
            return View(questTemplateDto);
        }

        // GET: QuestTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var questTemplateDto = this.questTemplateService.GetViewById(id);
            if (questTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(questTemplateDto);
        }

        // POST: QuestTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var questTemplateDto = this.questTemplateService.GetViewById(id);
            try
            {
                this.questTemplateService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(questTemplateDto);
            }

            return RedirectToAction("Index");
        }
    }
}
