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
using RemindMe.Models;

namespace RemindMe.Controllers
{
    public class remindmesController : ApiController
    {
        private remindmeEntities1 db = new remindmeEntities1();

        // GET: api/remindmes
        public IQueryable<remindme> Getremindmes()
        {
            return db.remindmes;
        }

        // GET: api/remindmes/5
        [ResponseType(typeof(remindme))]
        public IHttpActionResult Getremindme(int id)
        {
            remindme remindme = db.remindmes.Find(id);
            if (remindme == null)
            {
                return NotFound();
            }

            return Ok(remindme);
        }

        // PUT: api/remindmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putremindme(int id, remindme remindme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != remindme.id)
            {
                return BadRequest();
            }

            db.Entry(remindme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!remindmeExists(id))
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

        // POST: api/remindmes
        [ResponseType(typeof(remindme))]
        public IHttpActionResult Postremindme(remindme remindme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.remindmes.Add(remindme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = remindme.id }, remindme);
        }

        // DELETE: api/remindmes/5
        [ResponseType(typeof(remindme))]
        public IHttpActionResult Deleteremindme(int id)
        {
            remindme remindme = db.remindmes.Find(id);
            if (remindme == null)
            {
                return NotFound();
            }

            db.remindmes.Remove(remindme);
            db.SaveChanges();

            return Ok(remindme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool remindmeExists(int id)
        {
            return db.remindmes.Count(e => e.id == id) > 0;
        }
    }
}