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
    public class ConhecimentoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Conhecimento
        public IQueryable<Conhecimento> GetConhecimento()
        {
            return db.Conhecimento;
        }

        // GET: api/Conhecimento/5
        [ResponseType(typeof(Conhecimento))]
        public async Task<IHttpActionResult> GetConhecimento(int id)
        {
            Conhecimento conhecimento = await db.Conhecimento.FindAsync(id);
            if (conhecimento == null)
            {
                return NotFound();
            }

            return Ok(conhecimento);
        }

        // PUT: api/Conhecimento/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConhecimento(int id, Conhecimento conhecimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conhecimento.Id)
            {
                return BadRequest();
            }

            db.Entry(conhecimento).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConhecimentoExists(id))
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

        // POST: api/Conhecimento
        [ResponseType(typeof(Conhecimento))]
        public async Task<IHttpActionResult> PostConhecimento(Conhecimento conhecimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Conhecimento.Add(conhecimento);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = conhecimento.Id }, conhecimento);
        }

        // DELETE: api/Conhecimento/5
        [ResponseType(typeof(Conhecimento))]
        public async Task<IHttpActionResult> DeleteConhecimento(int id)
        {
            Conhecimento conhecimento = await db.Conhecimento.FindAsync(id);
            if (conhecimento == null)
            {
                return NotFound();
            }

            db.Conhecimento.Remove(conhecimento);
            await db.SaveChangesAsync();

            return Ok(conhecimento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConhecimentoExists(int id)
        {
            return db.Conhecimento.Count(e => e.Id == id) > 0;
        }
    }
}