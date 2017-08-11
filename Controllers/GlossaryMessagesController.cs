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
    public class GlossaryMessagesController : Controller
    {
        private AO_Entities db = new AO_Entities();

        // GET: GlossaryMessages
        public async Task<ActionResult> Index()
        {
            var glossaryMessages = db.GlossaryMessages.Include(g => g.GlossaryMessageTypeCategory);
            return View(await glossaryMessages.ToListAsync());
        }

        // GET: GlossaryMessages/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessage glossaryMessage = await db.GlossaryMessages.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "GlossaryMessageTypeCategoryId,Id,Note,Description,Text,IsBulletPoint,ReplacedBy_GlossaryMessageId,Enabled,Created,Modified")] GlossaryMessage glossaryMessage)
        {
            if (ModelState.IsValid)
            {
                db.GlossaryMessages.Add(glossaryMessage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GlossaryMessageTypeCategoryId = new SelectList(db.GlossaryMessageTypeCategories, "Id", "Name", glossaryMessage.GlossaryMessageTypeCategoryId);
            return View(glossaryMessage);
        }

        // GET: GlossaryMessages/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessage glossaryMessage = await db.GlossaryMessages.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "GlossaryMessageTypeCategoryId,Id,Note,Description,Text,IsBulletPoint,ReplacedBy_GlossaryMessageId,Enabled,Created,Modified")] GlossaryMessage glossaryMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glossaryMessage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GlossaryMessageTypeCategoryId = new SelectList(db.GlossaryMessageTypeCategories, "Id", "Name", glossaryMessage.GlossaryMessageTypeCategoryId);
            return View(glossaryMessage);
        }

        // GET: GlossaryMessages/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlossaryMessage glossaryMessage = await db.GlossaryMessages.FindAsync(id);
            if (glossaryMessage == null)
            {
                return HttpNotFound();
            }
            return View(glossaryMessage);
        }

        // POST: GlossaryMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            GlossaryMessage glossaryMessage = await db.GlossaryMessages.FindAsync(id);
            db.GlossaryMessages.Remove(glossaryMessage);
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
