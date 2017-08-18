using System.Net;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using WebAPIappHabor.Models;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Cors;

namespace WebAPIappHabor.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProfissionalController : ApiController
    {
        private Context db = new Context();

        public IQueryable<Profissional> GetProfissional()
        {
            return db.Profissional;
        }

        [Route("GetProfissionalProposta")]
        [ResponseType(typeof(Profissional))]
        public IHttpActionResult GetProfissionalProposta(int id)
        {
            List<Profissional> profissional = db.Profissional.Include("Proposta").Where(x => x.ID == id).ToList();
            if (profissional == null)
            {
                return NotFound();
            }

            return Ok(profissional);
        }

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

        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfissional(int id, Profissional profissional)
        {
            if (profissional == null)
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

        [ResponseType(typeof(Profissional))]
        public IHttpActionResult PostProfissional(Profissional profissional)
        {
            if (profissional == null)
            {
                return BadRequest(ModelState);
            }

            //profissional.Profissional_Conhecimento = null;
            //profissional.Proposta = null;

            db.Profissional.Add(profissional);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profissional.ID }, profissional);
        }

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