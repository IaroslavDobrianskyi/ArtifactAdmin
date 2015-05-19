using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtifactAdmin.DAL;

namespace ArtifactAdmin.Controllers
{
    public class StepTemplatesController : Controller
    {
        private artEntities db = new artEntities();

        // GET: StepTemplates
        public ActionResult Index()
        {
            return View(db.StepTemplates.Include("StepObjectStepTemplates").ToList());
        }

        // GET: StepTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepTemplate stepTemplate = db.StepTemplates.Find(id);
            if (stepTemplate == null)
            {
                return HttpNotFound();
            }
            string[] selObj = GetSelObj(id);
            StepTemplates modi = GetStepTemplate(stepTemplate, selObj);
            return View(modi);
        }

        // GET: StepTemplates/Create
       
        public ActionResult Create()
        {
            StepTemplates modi = GetStepTemplate(null, null);
            return View(modi);
        }
        
        private StepTemplates GetStepTemplate(StepTemplate stepTemplate, string[] selObj)
        {
            StepTemplates modi = new StepTemplates();
            modi.StepObjectType = db.StepObjectTypes.ToList();
            modi.StepObjectType.Add(null);
            modi.StepTemplate = stepTemplate;
            var AllObject = db.StepObjects;
            var ViewTV = new List<ViewStepObject>();
            foreach (var type in AllObject)
            {
                ViewTV.Add(new ViewStepObject
                {
                    stepObject = type,
                    IdObjType = type.id.ToString() + "." + type.StepObjectType.ToString()
                });
            }
            if (selObj == null)
            {
                modi.StepObject = ViewTV;
                modi.SelectedStepObject = new List<ViewStepObject>();
            }
            else 
            {
                modi.StepObject = new List<ViewStepObject>();
                modi.SelectedStepObject = new List<ViewStepObject>();
                bool sel = false;  
                foreach (var type in ViewTV)
                {
                    sel = false;
                    for (int i = 0; i < selObj.Length; i++) 
                     {
                        if (type.IdObjType == selObj[i])
                        { sel = true;
                        break;
                        }
                     }
                    if (sel)
                    {
                        modi.SelectedStepObject.Add(type);
                    }
                    else 
                    {
                        modi.StepObject.Add(type);
                    }
                } 
            }
            return modi;
        }
        // POST: StepTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Description,StepText,Name")] StepTemplate stepTemplate, string[] selectedStepObject)
           
        {
            StepTemplates modi = GetStepTemplate(stepTemplate, selectedStepObject);
            if (ModelState.IsValid)
            {
                try
                {
                    db.StepTemplates.Add(stepTemplate);
                    if (selectedStepObject != null)
                    { 
                    int SelLen = selectedStepObject.Length;
                    int Sobj = 0;
                    StepObjectStepTemplate[] NextObj = new StepObjectStepTemplate[SelLen];
                    for (int i = 0; i < SelLen; i++) 
                    {
                        Sobj = Convert.ToInt32(selectedStepObject[i].Substring(0, selectedStepObject[i].IndexOf('.')));
                        NextObj[i] = db.StepObjectStepTemplates.Add(new StepObjectStepTemplate { StepObject = Sobj, StepTemplate = stepTemplate.id });
                    }
                    }
                        db.SaveChanges();
                }
                catch 
                {
                    ViewBag.Error = "Помилка при створенні нового запису";
                    return View(modi);
                }
                return RedirectToAction("Index");
            }
 
            return View(modi);
        }

        // GET: StepTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepTemplate stepTemplate = db.StepTemplates.Find(id);
            if (stepTemplate == null)
            {
                return HttpNotFound();
            }
            string[] selObj = GetSelObj(id);
            StepTemplates modi = GetStepTemplate(stepTemplate, selObj);
            return View(modi);
        }

        private string[] GetSelObj(int? id)
        {
            // throw new NotImplementedException();
            string[] selObj = null;
            var ST = db.StepObjectStepTemplates.Include("StepObject1").Where(p => p.StepTemplate == id);
            int i = 0;
            int CountST = ST.Count();
            if (CountST > 0)
            {
                selObj = new string[CountST];
                foreach (var type in ST)
                {
                    selObj[i] = type.StepObject1.id.ToString() + "." + type.StepObject1.StepObjectType.ToString();
                    i++;
                }
            }
            return selObj;
        }

        // POST: StepTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Description,StepText,Name")] StepTemplate stepTemplate, string[] selectedStepObject)
        {
            StepTemplates modi = GetStepTemplate(stepTemplate, selectedStepObject);
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(stepTemplate).State = EntityState.Modified;
                    var ForDel =
                    db.StepObjectStepTemplates.Where(p => p.StepTemplate == stepTemplate.id);
                    foreach (var type in ForDel) 
                    {
                        db.StepObjectStepTemplates.Remove(type);
                    }
                    if (selectedStepObject != null)
                    {
                        int SelLen = selectedStepObject.Length;
                        int Sobj = 0;
                        StepObjectStepTemplate[] NextObj = new StepObjectStepTemplate[SelLen];
                        for (int i = 0; i < SelLen; i++)
                        {
                            Sobj = Convert.ToInt32(selectedStepObject[i].Substring(0, selectedStepObject[i].IndexOf('.')));
                            NextObj[i] = db.StepObjectStepTemplates.Add(new StepObjectStepTemplate { StepObject = Sobj, StepTemplate = stepTemplate.id });
                        }
                    }
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Помилка при спробі змінити запис";
                    return View(modi);
                }
                return RedirectToAction("Index");
            }
            return View(modi);
        }

        // GET: StepTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepTemplate stepTemplate = db.StepTemplates.Find(id);
            if (stepTemplate == null)
            {
                return HttpNotFound();
            }
            return View(stepTemplate);
        }

        // POST: StepTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StepTemplate stepTemplate = db.StepTemplates.Find(id);
            try
            {
                db.StepTemplates.Remove(stepTemplate);
                db.SaveChanges();
            }
            catch
            {
                ViewBag.Error = "Помилка при видаленні запису !";
                return View(stepTemplate);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
