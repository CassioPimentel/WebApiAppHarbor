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
using WebAPIappHabor.Models;

namespace WebAPIappHabor.Controllers
{
    public class ProfissionalController : ApiController
    {
        private Context db = new Context();

        // GET: api/Profissional
        public IQueryable<Profissional> GetProfissional()
        {
            return db.Profissional;
        }

        // GET: api/Profissional/5
        [ResponseType(typeof(Profissional))]
        public IHttpActionResult GetProfissional(int id)
        {
            Profissional profissional = db.Profissional.Find(id);
            if (profissional == null)
            {
                return NotFound();
            }

            return Ok(profissional);
        }

        // PUT: api/Profissional/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfissional(int id, Profissional profissional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profissional.ID)
            {
                return BadRequest();
            }

            db.Entry(profissional).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfissionalExists(id))
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

        // POST: api/Profissional
        [ResponseType(typeof(Profissional))]
        public IHttpActionResult PostProfissional(Profissional profissional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            profissional.Profissional_Conhecimento = null;
            profissional.Proposta = null;

            db.Profissional.Add(profissional);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profissional.ID }, profissional);
        }

        // DELETE: api/Profissional/5
        [ResponseType(typeof(Profissional))]
        public IHttpActionResult DeleteProfissional(int id)
        {
            Profissional profissional = db.Profissional.Find(id);
            if (profissional == null)
            {
                return NotFound();
            }

            db.Profissional.Remove(profissional);
            db.SaveChanges();

            return Ok(profissional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfissionalExists(int id)
        {
            return db.Profissional.Count(e => e.ID == id) > 0;
        }
    }
}