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
using PlayersDatav1;

namespace rtest.Controllers
{
    public class DrzavasController : ApiController
    {
        private PlayersContext db = new PlayersContext();

        // GET: api/Drzavas
        public IQueryable<Drzava> GetDrzavas()
        {
            return db.Drzavas;
        }

        // GET: api/Drzavas/5
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult GetDrzava(int id)
        {
            Drzava drzava = db.Drzavas.Find(id);
            if (drzava == null)
            {
                return NotFound();
            }

            return Ok(drzava);
        }

        // PUT: api/Drzavas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrzava(int id, Drzava drzava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drzava.ID)
            {
                return BadRequest();
            }

            db.Entry(drzava).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrzavaExists(id))
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

        // POST: api/Drzavas
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult PostDrzava(Drzava drzava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            db.Drzavas.Add(drzava);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drzava.ID }, drzava);
        }

        // DELETE: api/Drzavas/5
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult DeleteDrzava(int id)
        {
            Drzava drzava = db.Drzavas.Find(id);
            if (drzava == null)
            {
                return NotFound();
            }

            db.Drzavas.Remove(drzava);
            db.SaveChanges();

            return Ok(drzava);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrzavaExists(int id)
        {
            return db.Drzavas.Count(e => e.ID == id) > 0;
        }
    }
}