using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmissionsWeb.Models;

namespace AdmissionsWeb.Controllers
{
    public class GlossaryMessageTypeCategoriesController : Controller
    {
        private AO_Entities db = new AO_Entities();

        // GET: GlossaryMessageTypeCategories
        public ActionResult Index()
        {
            var glossaryMessageTypeCategories = db.GlossaryMessageTypeCategories.Include(g => g.GlossaryMessageType);
            return View(glossaryMessageTypeCategories.ToList());
        }

        // GET: GlossaryMessageTypeCategories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessageTypeCategory glossaryMessageTypeCategory = db.GlossaryMessageTypeCategories.Find(id);
            if (glossaryMessageTypeCategory == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessageTypeCategory);
        }

        // GET: GlossaryMessageTypeCategories/Create
        public ActionResult Create()
        {
            ViewBag.GlossaryMessageTypeId = new SelectList(db.GlossaryMessageTypes, "Id", "Name");
            return View();
        }

        // POST: GlossaryMessageTypeCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GlossaryMessageTypeId,Name,Description,Enabled,Created,Modified")] GlossaryMessageTypeCategory glossaryMessageTypeCategory)
        {
            if (ModelState.IsValid)
            {
                glossaryMessageTypeCategory.Id = Guid.NewGuid();
                db.GlossaryMessageTypeCategories.Add(glossaryMessageTypeCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GlossaryMessageTypeId = new SelectList(db.GlossaryMessageTypes, "Id", "Name", glossaryMessageTypeCategory.GlossaryMessageTypeId);
            return View(glossaryMessageTypeCategory);
        }

        // GET: GlossaryMessageTypeCategories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessageTypeCategory glossaryMessageTypeCategory = db.GlossaryMessageTypeCategories.Find(id);
            if (glossaryMessageTypeCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.GlossaryMessageTypeId = new SelectList(db.GlossaryMessageTypes, "Id", "Name", glossaryMessageTypeCategory.GlossaryMessageTypeId);
            return View(glossaryMessageTypeCategory);
        }

        // POST: GlossaryMessageTypeCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GlossaryMessageTypeId,Name,Description,Enabled,Created,Modified")] GlossaryMessageTypeCategory glossaryMessageTypeCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glossaryMessageTypeCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlossaryMessageTypeId = new SelectList(db.GlossaryMessageTypes, "Id", "Name", glossaryMessageTypeCategory.GlossaryMessageTypeId);
            return View(glossaryMessageTypeCategory);
        }

        // GET: GlossaryMessageTypeCategories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessageTypeCategory glossaryMessageTypeCategory = db.GlossaryMessageTypeCategories.Find(id);
            if (glossaryMessageTypeCategory == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessageTypeCategory);
        }

        // POST: GlossaryMessageTypeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GlossaryMessageTypeCategory glossaryMessageTypeCategory = db.GlossaryMessageTypeCategories.Find(id);
            db.GlossaryMessageTypeCategories.Remove(glossaryMessageTypeCategory);
            db.SaveChanges();
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
