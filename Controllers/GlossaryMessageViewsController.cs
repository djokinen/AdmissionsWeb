using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AdmissionsWeb.Models;

namespace AdmissionsWeb.Controllers
{
    public class GlossaryMessageViewsController : ApiController
    {
        private AO_Entities db = new AO_Entities();

        // GET: api/GlossaryMessageViews
        public IQueryable<GlossaryMessageView> GetGlossaryMessageViews()
        {
            return db.GlossaryMessageViews;
        }

        // GET: api/GlossaryMessageViews/5
        [ResponseType(typeof(GlossaryMessageView))]
        public IHttpActionResult GetGlossaryMessageView(string id)
        {
            GlossaryMessageView glossaryMessageView = db.GlossaryMessageViews.Find(id);
            if (glossaryMessageView == null)
            {
                return NotFound();
            }

            return Ok(glossaryMessageView);
        }

        // PUT: api/GlossaryMessageViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGlossaryMessageView(string id, GlossaryMessageView glossaryMessageView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != glossaryMessageView.Name)
            {
                return BadRequest();
            }

            db.Entry(glossaryMessageView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlossaryMessageViewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GlossaryMessageViews
        [ResponseType(typeof(GlossaryMessageView))]
        public IHttpActionResult PostGlossaryMessageView(GlossaryMessageView glossaryMessageView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GlossaryMessageViews.Add(glossaryMessageView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GlossaryMessageViewExists(glossaryMessageView.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = glossaryMessageView.Name }, glossaryMessageView);
        }

        // DELETE: api/GlossaryMessageViews/5
        [ResponseType(typeof(GlossaryMessageView))]
        public IHttpActionResult DeleteGlossaryMessageView(string id)
        {
            GlossaryMessageView glossaryMessageView = db.GlossaryMessageViews.Find(id);
            if (glossaryMessageView == null)
            {
                return NotFound();
            }

            db.GlossaryMessageViews.Remove(glossaryMessageView);
            db.SaveChanges();

            return Ok(glossaryMessageView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GlossaryMessageViewExists(string id)
        {
            return db.GlossaryMessageViews.Count(e => e.Name == id) > 0;
        }
    }
}