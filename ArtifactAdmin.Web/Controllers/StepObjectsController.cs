// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectsController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class StepObjectsController : Controller
    {
        private IStepObjectService stepObjectService;
        private IStepObjectTypeService stepObjectTypeService;

        public StepObjectsController(IStepObjectService stepObjectService, IStepObjectTypeService stepObjectTypeService)
        {
            this.stepObjectService = stepObjectService;
            this.stepObjectTypeService = stepObjectTypeService;
        }

        // GET: StepObjects
        public ActionResult Index()
        {
            return View(this.stepObjectService.GetAll());
        }

        // GET: StepObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var stepObject = this.stepObjectService.GetById(id);

            if (stepObject == null)
            {
                return HttpNotFound();
            }
            
            return View(stepObject);
        }

        // GET: StepObjects/Create
        public ActionResult Create()
        {
            ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: StepObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StepObjectType,Name,Description,Icon")] StepObjectDto stepObject, HttpPostedFileBase Icon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var fileNameForSave = FileHelper.SaveIcon("StepObjects", Icon);
                if (string.IsNullOrEmpty(fileNameForSave))
                {
                    ViewBag.Error = "Помилка при збереженні іконки";
                    ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "id", "Name", stepObject.StepObjectType);
                    return View(stepObject);
                }

                try
                {
                    this.stepObjectService.Create(stepObject, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "id", "Name", stepObject.StepObjectType);
                    return View(stepObject);
                }

                return RedirectToAction("Index");
            }

            ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "id", "Name", stepObject.StepObjectType);
            return View(stepObject);
        }

        // GET: StepObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stepObject = this.stepObjectService.GetById(id);
            if (stepObject == null)
            {
                return HttpNotFound();
            }

            ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "id", "Name", stepObject.StepObjectType);
            return View(stepObject);
        }

        // POST: StepObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StepObjectType,Name,Description,Icon")] StepObjectDto stepObject, HttpPostedFileBase NewIcon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var oldfileName = stepObject.Icon;
                var fileNameForSave = oldfileName;
                if (NewIcon != null)
                {
                    fileNameForSave = FileHelper.SaveIcon("StepObjects", NewIcon);
                    if (string.IsNullOrEmpty(fileNameForSave))
                    {
                        ViewBag.Error = "Помилка при збереженні іконки";
                        return View(stepObject);
                    }
                }

                try
                {
                    this.stepObjectService.Update(stepObject, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "id", "Name", stepObject.StepObjectType);
                    return View(stepObject);
                }

                if (oldfileName != fileNameForSave)
                {
                    FileHelper.DeleteIcon(oldfileName, "StepObjects");
                }

                return RedirectToAction("Index");
            }

            ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "id", "Name", stepObject.StepObjectType);
            return View(stepObject);
        }

        // GET: StepObjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stepObject = this.stepObjectService.GetById(id);
            if (stepObject == null)
            {
                return HttpNotFound();
            }

            return View(stepObject);
        }

        // POST: StepObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var stepObject = this.stepObjectService.GetById(id);
            var fileName = stepObject.Icon;
            try
            {
                this.stepObjectService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                ViewBag.StepObjectType = new SelectList(this.stepObjectTypeService.GetAll(), "id", "Name", stepObject.StepObjectType);
                return View(stepObject);
            }

            FileHelper.DeleteIcon(fileName, "StepObjects");
            return RedirectToAction("Index");
        }
    }
}
