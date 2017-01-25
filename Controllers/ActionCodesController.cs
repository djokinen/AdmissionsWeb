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
    public class ActionCodesController : Controller
    {
        private AO_Entities db = new AO_Entities();

        // GET: ActionCodes
        public ActionResult Index()
        {
            return View(db.ActionCodes.ToList());
        }

        // GET: ActionCodes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionCode actionCode = db.ActionCodes.Find(id);
            if (actionCode == null)
            {
                return HttpNotFound();
            }
            return View(actionCode);
        }

        // GET: ActionCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActionCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Enabled,CreatedDate,Modified")] ActionCode actionCode)
        {
            if (ModelState.IsValid)
            {
                db.ActionCodes.Add(actionCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actionCode);
        }

        // GET: ActionCodes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionCode actionCode = db.ActionCodes.Find(id);
            if (actionCode == null)
            {
                return HttpNotFound();
            }
            return View(actionCode);
        }

        // POST: ActionCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Enabled,CreatedDate,Modified")] ActionCode actionCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actionCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actionCode);
        }

        // GET: ActionCodes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionCode actionCode = db.ActionCodes.Find(id);
            if (actionCode == null)
            {
                return HttpNotFound();
            }
            return View(actionCode);
        }

        // POST: ActionCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ActionCode actionCode = db.ActionCodes.Find(id);
            db.ActionCodes.Remove(actionCode);
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
