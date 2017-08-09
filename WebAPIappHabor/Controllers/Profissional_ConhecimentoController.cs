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
    public class Profissional_ConhecimentoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Profissional_Conhecimento
        public IQueryable<Profissional_Conhecimento> GetProfissional_Conhecimento()
        {
            return db.Profissional_Conhecimento;
        }

        // GET: api/Profissional_Conhecimento/5
        [ResponseType(typeof(Profissional_Conhecimento))]
        public async Task<IHttpActionResult> GetProfissional_Conhecimento(int id)
        {
            Profissional_Conhecimento profissional_Conhecimento = await db.Profissional_Conhecimento.FindAsync(id);
            if (profissional_Conhecimento == null)
            {
                return NotFound();
            }

            return Ok(profissional_Conhecimento);
        }

        // PUT: api/Profissional_Conhecimento/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProfissional_Conhecimento(int id, Profissional_Conhecimento profissional_Conhecimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profissional_Conhecimento.Id)
            {
                return BadRequest();
            }

            db.Entry(profissional_Conhecimento).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Profissional_ConhecimentoExists(id))
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

        // POST: api/Profissional_Conhecimento
        [ResponseType(typeof(Profissional_Conhecimento))]
        public async Task<IHttpActionResult> PostProfissional_Conhecimento(Profissional_Conhecimento profissional_Conhecimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profissional_Conhecimento.Add(profissional_Conhecimento);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = profissional_Conhecimento.Id }, profissional_Conhecimento);
        }

        // DELETE: api/Profissional_Conhecimento/5
        [ResponseType(typeof(Profissional_Conhecimento))]
        public async Task<IHttpActionResult> DeleteProfissional_Conhecimento(int id)
        {
            Profissional_Conhecimento profissional_Conhecimento = await db.Profissional_Conhecimento.FindAsync(id);
            if (profissional_Conhecimento == null)
            {
                return NotFound();
            }

            db.Profissional_Conhecimento.Remove(profissional_Conhecimento);
            await db.SaveChangesAsync();

            return Ok(profissional_Conhecimento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Profissional_ConhecimentoExists(int id)
        {
            return db.Profissional_Conhecimento.Count(e => e.Id == id) > 0;
        }
    }
}