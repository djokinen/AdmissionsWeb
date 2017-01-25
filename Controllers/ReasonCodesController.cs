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
    public class ReasonCodesController : Controller
    {
        private AO_Entities db = new AO_Entities();

        // GET: ReasonCodes
        public ActionResult Index()
        {
            return View(db.ReasonCodes.ToList());
        }

        // GET: ReasonCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReasonCode reasonCode = db.ReasonCodes.Find(id);
            if (reasonCode == null)
            {
                return HttpNotFound();
            }
            return View(reasonCode);
        }

        // GET: ReasonCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReasonCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Enabled,CreatedDate,Modified")] ReasonCode reasonCode)
        {
            if (ModelState.IsValid)
            {
                db.ReasonCodes.Add(reasonCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reasonCode);
        }

        // GET: ReasonCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReasonCode reasonCode = db.ReasonCodes.Find(id);
            if (reasonCode == null)
            {
                return HttpNotFound();
            }
            return View(reasonCode);
        }

        // POST: ReasonCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Enabled,CreatedDate,Modified")] ReasonCode reasonCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reasonCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reasonCode);
        }

        // GET: ReasonCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReasonCode reasonCode = db.ReasonCodes.Find(id);
            if (reasonCode == null)
            {
                return HttpNotFound();
            }
            return View(reasonCode);
        }

        // POST: ReasonCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReasonCode reasonCode = db.ReasonCodes.Find(id);
            db.ReasonCodes.Remove(reasonCode);
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
