// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionDescriptionsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionDescriptionsController type.
// </summary>
// -------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class ActionDescriptionsController : Controller
    {
        private IActionDescriptionService actionDescriptionService;

        public ActionDescriptionsController(IActionDescriptionService actionDescriptionService) 
        {
            this.actionDescriptionService = actionDescriptionService;
        }

        // GET: ActionDescriptions
        public ActionResult Index()
        {
            return View(this.actionDescriptionService.GetAll());
        }

        // GET: ActionDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewActionDescriptionDto = this.actionDescriptionService.GetViewById(id);
            if (viewActionDescriptionDto == null)
            {
                return HttpNotFound();
            }

            return View(viewActionDescriptionDto);
        }

        // GET: ActionDescriptions/Create
        public ActionResult Create()
        {
            var viewActionDescriptionDto = this.actionDescriptionService.GetViewById(null);
            return View(viewActionDescriptionDto);
        }

        // POST: ActionDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActionTemplate,MapZone,ActionText")] ActionDescriptionDto actionDescriptionDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewActioDescriptionDto = new ViewActionDescriptionDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.actionDescriptionService.Create(actionDescriptionDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    viewActioDescriptionDto = this.actionDescriptionService.GetViewById(actionDescriptionDto.Id);
                    return View(viewActioDescriptionDto);
                }

                return RedirectToAction("Index");
            }

            viewActioDescriptionDto = this.actionDescriptionService.GetViewById(actionDescriptionDto.Id);
            return View(viewActioDescriptionDto);
        }

        // GET: ActionDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewActionDescriptionDto = this.actionDescriptionService.GetViewById(id);
            if (viewActionDescriptionDto == null)
            {
                return HttpNotFound();
            }
            
            return View(viewActionDescriptionDto);
        }

        // POST: ActionDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActionTemplate,MapZone,ActionText")] ActionDescriptionDto actionDescriptionDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var viewActionDescriptionDto = new ViewActionDescriptionDto();
            if (ModelState.IsValid)
            {
                try
                {
                    this.actionDescriptionService.Update(actionDescriptionDto);
                }
                catch (Exception e) 
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    viewActionDescriptionDto = this.actionDescriptionService.GetViewById(actionDescriptionDto.Id);
                    return View(viewActionDescriptionDto);
                }

                return RedirectToAction("Index");
            }

            viewActionDescriptionDto = this.actionDescriptionService.GetViewById(actionDescriptionDto.Id);
            return View(actionDescriptionDto);
        }

        // GET: ActionDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actionDescriptionDto = this.actionDescriptionService.GetById(id);
            if (actionDescriptionDto == null)
            {
                return HttpNotFound();
            }

            return View(actionDescriptionDto);
        }

        // POST: ActionDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var actionDescriptionDto = this.actionDescriptionService.GetById(id);
            try 
            {
                this.actionDescriptionService.Delete(id);
            }
            catch (Exception e) 
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(actionDescriptionDto);
            }

            return RedirectToAction("Index");
        }
    }
}
