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
    public class GlossaryMessageTypesController : Controller
    {
        private AO_Entities db = new AO_Entities();

        // GET: GlossaryMessageTypes
        public ActionResult Index()
        {
            return View(db.GlossaryMessageTypes.ToList());
        }

        // GET: GlossaryMessageTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessageType glossaryMessageType = db.GlossaryMessageTypes.Find(id);
            if (glossaryMessageType == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessageType);
        }

        // GET: GlossaryMessageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlossaryMessageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Enabled,Created,Modified")] GlossaryMessageType glossaryMessageType)
        {
            if (ModelState.IsValid)
            {
                glossaryMessageType.Id = Guid.NewGuid();
                db.GlossaryMessageTypes.Add(glossaryMessageType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glossaryMessageType);
        }

        // GET: GlossaryMessageTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessageType glossaryMessageType = db.GlossaryMessageTypes.Find(id);
            if (glossaryMessageType == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessageType);
        }

        // POST: GlossaryMessageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Enabled,Created,Modified")] GlossaryMessageType glossaryMessageType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glossaryMessageType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glossaryMessageType);
        }

        // GET: GlossaryMessageTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessageType glossaryMessageType = db.GlossaryMessageTypes.Find(id);
            if (glossaryMessageType == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessageType);
        }

        // POST: GlossaryMessageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GlossaryMessageType glossaryMessageType = db.GlossaryMessageTypes.Find(id);
            db.GlossaryMessageTypes.Remove(glossaryMessageType);
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
