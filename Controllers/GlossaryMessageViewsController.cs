using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
		public IQueryable<GlossaryMessageView> GetGlossaryMessageViews(string codes)
		{
			return (from n in db.GlossaryMessageViews
					  where codes.Contains(n.Code)
					  select n);
		}

		// GET: api/GlossaryMessageViews/5
		[ResponseType(typeof(GlossaryMessageView))]
        public async Task<IHttpActionResult> GetGlossaryMessageView(string id)
        {
            GlossaryMessageView glossaryMessageView = await db.GlossaryMessageViews.FindAsync(id);
            if (glossaryMessageView == null)
            {
                return NotFound();
            }

            return Ok(glossaryMessageView);
        }

        // PUT: api/GlossaryMessageViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGlossaryMessageView(Guid id, GlossaryMessageView glossaryMessageView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != glossaryMessageView.Id)
            {
                return BadRequest();
            }

            db.Entry(glossaryMessageView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostGlossaryMessageView(GlossaryMessageView glossaryMessageView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GlossaryMessageViews.Add(glossaryMessageView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GlossaryMessageViewExists(glossaryMessageView.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = glossaryMessageView.Id }, glossaryMessageView);
        }

        // DELETE: api/GlossaryMessageViews/5
        [ResponseType(typeof(GlossaryMessageView))]
        public async Task<IHttpActionResult> DeleteGlossaryMessageView(Guid id)
        {
            GlossaryMessageView glossaryMessageView = await db.GlossaryMessageViews.FindAsync(id);
            if (glossaryMessageView == null)
            {
                return NotFound();
            }

            db.GlossaryMessageViews.Remove(glossaryMessageView);
            await db.SaveChangesAsync();

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

        private bool GlossaryMessageViewExists(Guid id)
        {
            return db.GlossaryMessageViews.Count(e => e.Id == id) > 0;
        }
    }
}