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
    public class IgracsController : ApiController
    {
        private PlayersContext db = new PlayersContext();

        // GET: api/Igracs
        public IQueryable<Igrac> GetIgracs()
        {
            return db.Igracs;
        }

        // GET: api/Igracs/5
        [ResponseType(typeof(Igrac))]
        public IHttpActionResult GetIgrac(int id)
        {
            Igrac igrac = db.Igracs.Find(id);
            if (igrac == null)
            {
                return NotFound();
            }

            return Ok(igrac);
        }

        // PUT: api/Igracs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIgrac(int id, Igrac igrac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != igrac.ID)
            {
                return BadRequest();
            }

            db.Entry(igrac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IgracExists(id))
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

        // POST: api/Igracs
        [ResponseType(typeof(Igrac))]
        public IHttpActionResult PostIgrac(Igrac igrac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Igracs.Add(igrac);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = igrac.ID }, igrac);
        }

        // DELETE: api/Igracs/5
        [ResponseType(typeof(Igrac))]
        public IHttpActionResult DeleteIgrac(int id)
        {
            Igrac igrac = db.Igracs.Find(id);
            if (igrac == null)
            {
                return NotFound();
            }

            db.Igracs.Remove(igrac);
            db.SaveChanges();

            return Ok(igrac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IgracExists(int id)
        {
            return db.Igracs.Count(e => e.ID == id) > 0;
        }
    }
}