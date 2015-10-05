// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TalentsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the TalentsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.Web.Controllers
{
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
            TalentDto talent, HttpPostedFileBase icon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var fileNameForSave = FileHelper.SaveIcon("Talents", icon);
                if (string.IsNullOrEmpty(fileNameForSave))
                {
                    ViewBag.Error = "Помилка при збереженні іконки";
                    return View(talent);
                }

                try
                {
                    this.talentService.Create(talent, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return View(talent);
                }
                
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
        public ActionResult Edit([Bind(Include = "Id,Description,Name,MaxLevel,Modifier,BaseValue,BaseModifier,Icon")] TalentDto talent, HttpPostedFileBase newIcon)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                var oldfileName = talent.Icon;
                var fileNameForSave = oldfileName;
                if (newIcon != null)
                {
                    fileNameForSave = FileHelper.SaveIcon("Talents", newIcon);
                    if (string.IsNullOrEmpty(fileNameForSave))
                    {
                        ViewBag.Error = "Помилка при збереженні іконки";
                        return View(talent);
                    }
                }

                try
                {
                    this.talentService.Update(talent, fileNameForSave);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(talent);
                }

                if (oldfileName != fileNameForSave)
                {
                    FileHelper.DeleteIcon(oldfileName, "ConstellationsTalents");
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
            var fileName = talent.Icon;
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

            FileHelper.DeleteIcon(fileName, "Talents");
            return RedirectToAction("Index");
        }
    }
}
