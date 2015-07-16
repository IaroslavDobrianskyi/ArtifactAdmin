// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacteristicsController.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the CharacteristicsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using BL.Interfaces;
    using BL.ModelsDTO;

    public class CharacteristicsController : Controller
    {
        private ICharacteristicService characteristicService;

        public CharacteristicsController(ICharacteristicService characteristicService)
        {
            this.characteristicService = characteristicService;
        }

        // GET: Characteristics
        public ActionResult Index()
        {
            return View(this.characteristicService.GetAll());
        }

        // GET: Characteristics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var characteristicDto = this.characteristicService.GetById(id);
            if (characteristicDto == null)
            {
                return HttpNotFound();
            }

            return View(characteristicDto);
        }

        // GET: Characteristics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characteristics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Mask,Length,Position")] CharacteristicDto characteristicDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.characteristicService.Create(characteristicDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    ViewBag.ErrMes = e.Message;
                    return this.View(characteristicDto);
                }
                return RedirectToAction("Index");
            }

            return View(characteristicDto);
        }

        // GET: Characteristics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var characteristicDto = this.characteristicService.GetById(id);
            if (characteristicDto == null)
            {
                return HttpNotFound();
            }

            return View(characteristicDto);
        }

        // POST: Characteristics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Mask,Length,Position")] CharacteristicDto characteristicDto)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    this.characteristicService.Update(characteristicDto);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    ViewBag.ErrMes = e.Message;
                    return View(characteristicDto);
                }

                return RedirectToAction("Index");
            }

            return View(characteristicDto);
        }

        // GET: Characteristics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var characteristicDto = this.characteristicService.GetById(id);
            if (characteristicDto == null)
            {
                return HttpNotFound();
            }

            return View(characteristicDto);
        }

        // POST: Characteristics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Error = string.Empty;
            ViewBag.ErrMes = string.Empty;
            var characteristicDto = this.characteristicService.GetById(id);
            try
            {
                this.characteristicService.Delete(id);
            }
            catch(Exception e)
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                ViewBag.ErrMes = e.Message;
                return View(characteristicDto);
            }

            return RedirectToAction("Index");
        }
    }
}
