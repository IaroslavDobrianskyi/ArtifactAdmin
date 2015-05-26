// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TalentsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the TalentsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;
    
    public class TalentsController : Controller
    {
        private ITalentService talentService;

        public TalentsController(ITalentService talentService)
        {
            this.talentService = talentService;
        }

        // GET: Talents
        public ActionResult Index()
        {
            return View(this.talentService.GetAll());
        }

        // GET: Talents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var talent = this.talentService.GetById(id);
            if (talent == null)
            {
                return HttpNotFound();
            }

            return View(talent);
        }

        // GET: Talents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Name,MaxLevel,Modifier,BaseValue,BaseModifier,Icon")]
            TalentDto talent, HttpPostedFileBase Icon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.talentService.Create(talent, Icon);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(talent);
                }

                this.talentService.SaveIcon(talent, Icon);
                return RedirectToAction("Index");
            }

            return View(talent);
        }

        // GET: Talents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var talent = this.talentService.GetById(id);
            if (talent == null)
            {
                return HttpNotFound();
            }

            return View(talent);
        }

        // POST: Talents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Name,MaxLevel,Modifier,BaseValue,BaseModifier,Icon")] TalentDto talent)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.talentService.Update(talent);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(talent);
                }

                return RedirectToAction("Index");
            }

            return View(talent);
        }

        // GET: Talents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var talent = this.talentService.GetById(id);
            if (talent == null)
            {
                return HttpNotFound();
            }

            return View(talent);
        }

        // POST: Talents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var talent = this.talentService.GetById(id);
            try
            {
            this.talentService.Delete(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(talent);
            }

            return RedirectToAction("Index");
        }
    }
}
