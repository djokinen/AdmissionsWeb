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
    public class GlossaryMessagesController : Controller
    {
        private AO_Entities db = new AO_Entities();

        // GET: GlossaryMessages
        public ActionResult Index()
        {
            var glossaryMessages = db.GlossaryMessages.Include(g => g.GlossaryMessageTypeCategory);
            return View(glossaryMessages.ToList());
        }

        // GET: GlossaryMessages/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessage glossaryMessage = db.GlossaryMessages.Find(id);
            if (glossaryMessage == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessage);
        }

        // GET: GlossaryMessages/Create
        public ActionResult Create()
        {
            ViewBag.GlossaryMessageTypeCategoryId = new SelectList(db.GlossaryMessageTypeCategories, "Id", "Name");
            return View();
        }

        // POST: GlossaryMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GlossaryMessageTypeCategoryId,Code,Description,Text,Enabled,Created,Modified")] GlossaryMessage glossaryMessage)
        {
            if (ModelState.IsValid)
            {
                glossaryMessage.Id = Guid.NewGuid();
                db.GlossaryMessages.Add(glossaryMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GlossaryMessageTypeCategoryId = new SelectList(db.GlossaryMessageTypeCategories, "Id", "Name", glossaryMessage.GlossaryMessageTypeCategoryId);
            return View(glossaryMessage);
        }

        // GET: GlossaryMessages/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessage glossaryMessage = db.GlossaryMessages.Find(id);
            if (glossaryMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.GlossaryMessageTypeCategoryId = new SelectList(db.GlossaryMessageTypeCategories, "Id", "Name", glossaryMessage.GlossaryMessageTypeCategoryId);
            return View(glossaryMessage);
        }

        // POST: GlossaryMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GlossaryMessageTypeCategoryId,Code,Description,Text,Enabled,Created,Modified")] GlossaryMessage glossaryMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glossaryMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlossaryMessageTypeCategoryId = new SelectList(db.GlossaryMessageTypeCategories, "Id", "Name", glossaryMessage.GlossaryMessageTypeCategoryId);
            return View(glossaryMessage);
        }

        // GET: GlossaryMessages/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessage glossaryMessage = db.GlossaryMessages.Find(id);
            if (glossaryMessage == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessage);
        }

        // POST: GlossaryMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GlossaryMessage glossaryMessage = db.GlossaryMessages.Find(id);
            db.GlossaryMessages.Remove(glossaryMessage);
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
