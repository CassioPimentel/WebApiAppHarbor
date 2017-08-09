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
        public async Task<IHttpActionResult> GetProposta(int id)
        {
            Proposta proposta = await db.Proposta.FindAsync(id);
            if (proposta == null)
            {
                return NotFound();
            }

            return Ok(proposta);
        }

        // PUT: api/Proposta/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProposta(int id, Proposta proposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proposta.Id)
            {
                return BadRequest();
            }

            db.Entry(proposta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostProposta(Proposta proposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proposta.Add(proposta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = proposta.Id }, proposta);
        }

        // DELETE: api/Proposta/5
        [ResponseType(typeof(Proposta))]
        public async Task<IHttpActionResult> DeleteProposta(int id)
        {
            Proposta proposta = await db.Proposta.FindAsync(id);
            if (proposta == null)
            {
                return NotFound();
            }

            db.Proposta.Remove(proposta);
            await db.SaveChangesAsync();

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
            return db.Proposta.Count(e => e.Id == id) > 0;
        }
    }
}