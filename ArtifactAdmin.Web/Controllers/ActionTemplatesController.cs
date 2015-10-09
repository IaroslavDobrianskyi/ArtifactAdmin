// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplatesController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplatesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;
    using BL.Utils;

    public class ActionTemplatesController : Controller
    {
        private IActionTemplateService actionTemplateService;
        private IActionTemplateResultService actionTemplateResultService;

        public ActionTemplatesController(IActionTemplateService actionTemplateService, IActionTemplateResultService actionTemplateResultService) 
        {
            this.actionTemplateService = actionTemplateService;
            this.actionTemplateResultService = actionTemplateResultService;
        }

        // GET: ActionTemplates
        public ActionResult Index()
        {
            return View(this.actionTemplateService.GetAll());
        }

        // GET: ActionTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actionTemplateDto = this.actionTemplateService.GetById(id);
            if (actionTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(actionTemplateDto);
        }

        // GET: ActionTemplates/Create
        public ActionResult Create()
        {
            return View(this.actionTemplateService.GetViewById(null));
        }

        // POST: ActionTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Name,BlockProbability,ActionTemplateResult")] ActionTemplateDto actionTemplateDto,
            string predisposition,
            string experience,
            string posibility,
            string gold,
            int[] selectedCharacteristics,
            int[] selectedPredispositions,
            int[] lows,
            int[] highs,
            int[] selectedProperties,
            bool[] appearances)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    if (actionTemplateDto.ActionTemplateResult == 0)
                    {
                       var actionTemplateResultDto = new ActionTemplateResultDto();
                        actionTemplateResultDto.PredispositionResultModifier =
                            Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(predisposition));
                        actionTemplateResultDto.ExperienceModifier = Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(experience));
                        actionTemplateResultDto.ArtifactPosibility = Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(posibility));
                        actionTemplateResultDto.GoldModifier = Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(gold));
                        actionTemplateResultDto = this.actionTemplateResultService.Create(actionTemplateResultDto);
                        actionTemplateDto.ActionTemplateResult = actionTemplateResultDto.Id;
                    }

                    this.actionTemplateService.Create(actionTemplateDto, selectedCharacteristics, selectedPredispositions, lows, highs, selectedProperties, appearances); 
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(this.actionTemplateService.GetViewById(actionTemplateDto.Id));
                }
               
                return RedirectToAction("Index");
            }

            return View(this.actionTemplateService.GetViewById(actionTemplateDto.Id));
        }

        // GET: ActionTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewActionTemplateDto = this.actionTemplateService.GetViewById(id);
            if (viewActionTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(viewActionTemplateDto);
        }

        // POST: ActionTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BlockProbability,ActionTemplateResult")] ActionTemplateDto actionTemplateDto,
            string predisposition,
            string experience,
            string posibility,
            string gold,
            int[] selectedCharacteristics,
            int[] selectedPredispositions,
            int[] lows,
            int[] highs,
            int[] selectedProperties,
            bool[] appearances)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    if (actionTemplateDto.ActionTemplateResult == 0)
                    {
                        var actionTemplateResultDto = new ActionTemplateResultDto();
                        actionTemplateResultDto.PredispositionResultModifier =
                            Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(predisposition));
                        actionTemplateResultDto.ExperienceModifier = Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(experience));
                        actionTemplateResultDto.ArtifactPosibility = Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(posibility));
                        actionTemplateResultDto.GoldModifier = Convert.ToDouble(ViewHelper.ConvertToCurrentSeparator(gold));
                        actionTemplateResultDto = this.actionTemplateResultService.Create(actionTemplateResultDto);
                        actionTemplateDto.ActionTemplateResult = actionTemplateResultDto.Id;
                    }

                    this.actionTemplateService.Update(actionTemplateDto, selectedCharacteristics, selectedPredispositions, lows, highs, selectedProperties, appearances);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(this.actionTemplateService.GetViewById(actionTemplateDto.Id));
                }
                
                return RedirectToAction("Index");
            }

            return View(this.actionTemplateService.GetViewById(actionTemplateDto.Id));
        }

        // GET: ActionTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actionTemplateDto = this.actionTemplateService.GetById(id);
            if (actionTemplateDto == null)
            {
                return HttpNotFound();
            }

            return View(actionTemplateDto);
        }

        // POST: ActionTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var actionTemplateDto = this.actionTemplateService.GetById(id);
            try
            {
                this.actionTemplateService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(actionTemplateDto);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Modifier(int? id, string name)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewDesireActionResultDto = this.actionTemplateService.GetViewDesireResult(id, name);
            if (viewDesireActionResultDto == null)
            {
                return HttpNotFound();
            }

            return View(viewDesireActionResultDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(
            [Bind(Include = "ActionResultId,ActionName")] ViewDesireActionResultDto desireActionResultDto, int[] desireResultsDto, string[] modifiers)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewDesireActionResultDto = new ViewDesireActionResultDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.actionTemplateService.UpdateDesireActionResult(desireActionResultDto.ActionResultId, desireResultsDto, modifiers);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    viewDesireActionResultDto =
                        this.actionTemplateService.GetViewDesireResultByList(desireActionResultDto.ActionResultId,
                            desireActionResultDto.ActionName,
                            desireResultsDto,
                            modifiers);
                    return View(viewDesireActionResultDto);
                }

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Помилка при спробі змінити запис";
            ViewBag.ErrMes = ViewHelper.ModelStateExeption(ModelState);
            viewDesireActionResultDto =
                        this.actionTemplateService.GetViewDesireResultByList(desireActionResultDto.ActionResultId,
                            desireActionResultDto.ActionName,
                            desireResultsDto,
                            modifiers);
            return View(viewDesireActionResultDto);
        }
    }
}
