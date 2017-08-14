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
    public class PropostaController : ApiController
    {
        private Context db = new Context();

        // GET: api/Proposta
        public IQueryable<Proposta> GetProposta()
        {
            return db.Proposta;
        }

        // GET: api/Proposta/5
        [ResponseType(typeof(Proposta))]
        public IHttpActionResult GetProposta(int id)
        {
            Proposta proposta = db.Proposta.Find(id);
            if (proposta == null)
            {
                return NotFound();
            }

            return Ok(proposta);
        }

        // PUT: api/Proposta/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProposta(int id, Proposta proposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proposta.ID)
            {
                return BadRequest();
            }

            db.Entry(proposta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropostaExists(id))
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

        // POST: api/Proposta
        [ResponseType(typeof(Proposta))]
        public IHttpActionResult PostProposta(Proposta proposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Profissional = db.Profissional.Where(x => x.ID == proposta.Profissional_ID).FirstOrDefault();
            var Empresa = db.Empresa.Where(x => x.ID == proposta.Empresa_ID).FirstOrDefault();

            proposta.Profissional = Profissional;
            proposta.Empresa = Empresa;
            
            db.Proposta.Add(proposta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proposta.ID }, proposta);
        }

        // DELETE: api/Proposta/5
        [ResponseType(typeof(Proposta))]
        public IHttpActionResult DeleteProposta(int id)
        {
            Proposta proposta = db.Proposta.Find(id);
            if (proposta == null)
            {
                return NotFound();
            }

            db.Proposta.Remove(proposta);
            db.SaveChanges();

            return Ok(proposta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropostaExists(int id)
        {
            return db.Proposta.Count(e => e.ID == id) > 0;
        }
    }
}