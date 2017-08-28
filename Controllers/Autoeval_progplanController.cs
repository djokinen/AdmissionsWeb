using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmissionsWeb.Models;

namespace AdmissionsWeb.Controllers
{
    public class Autoeval_progplanController : Controller
    {
        private AO_Entities db = new AO_Entities();

        // GET: Autoeval_progplan
        public async Task<ActionResult> Index()
        {
            return View(await db.Autoeval_progplan.ToListAsync());
        }

        // GET: Autoeval_progplan/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autoeval_progplan autoeval_progplan = await db.Autoeval_progplan.FindAsync(id);
            if (autoeval_progplan == null)
            {
                return HttpNotFound();
            }
            return View(autoeval_progplan);
        }

        // GET: Autoeval_progplan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autoeval_progplan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudentID,ProgPlan")] Autoeval_progplan autoeval_progplan)
        {
            if (ModelState.IsValid)
            {
                db.Autoeval_progplan.Add(autoeval_progplan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(autoeval_progplan);
        }

        // GET: Autoeval_progplan/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autoeval_progplan autoeval_progplan = await db.Autoeval_progplan.FindAsync(id);
            if (autoeval_progplan == null)
            {
                return HttpNotFound();
            }
            return View(autoeval_progplan);
        }

        // POST: Autoeval_progplan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudentID,ProgPlan")] Autoeval_progplan autoeval_progplan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoeval_progplan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(autoeval_progplan);
        }

        // GET: Autoeval_progplan/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autoeval_progplan autoeval_progplan = await db.Autoeval_progplan.FindAsync(id);
            if (autoeval_progplan == null)
            {
                return HttpNotFound();
            }
            return View(autoeval_progplan);
        }

        // POST: Autoeval_progplan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Autoeval_progplan autoeval_progplan = await db.Autoeval_progplan.FindAsync(id);
            db.Autoeval_progplan.Remove(autoeval_progplan);
            await db.SaveChangesAsync();
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
