using System.Net;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using WebAPIappHabor.Models;
using System.Web.Http.Cors;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace WebAPIappHabor.Controllers
{
    //[EnableCors(origins: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProfissionalController : ApiController
    {
        private Context db = new Context();

        public IQueryable<Profissional> GetProfissional()
        {
            return db.Profissional.Include("Profissional_Conhecimento.Conhecimento");
        }

        [Route("GetProfissionalProposta")]
        [ResponseType(typeof(Profissional))]
        public IHttpActionResult GetProfissionalProposta(int id)
        {
            List<Profissional> profissional = db.Profissional.Include("Profissional_Conhecimento.Conhecimento").Where(x => x.ID == id).ToList();
            if (profissional == null)
            {
                return NotFound();
            }

            return Ok(profissional);
        }

        [ResponseType(typeof(Profissional))]
        public IHttpActionResult GetProfissional(int id)
        {
            Profissional profissional = db.Profissional.Include("Profissional_Conhecimento.Conhecimento").Where(x => x.ID == id).FirstOrDefault();
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

            //var Conhecimento_Profissional = db.Conhecimento.Where(x => x.ID == ).FirstOrDefault();


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

            List<Profissional_Conhecimento> ProfissionalConhecimento = db.Profissional_Conhecimento.Where(x => x.Profissional_ID == profissional.ID).ToList();

            foreach (var item in ProfissionalConhecimento)
            {
                db.Profissional_Conhecimento.Remove(item);
                db.SaveChanges();
            }

            List<Proposta> ProfissionalProposta = db.Proposta.Where(x => x.Profissional_ID == profissional.ID).ToList();

            foreach (var item in ProfissionalProposta)
            {
                db.Proposta.Remove(item);
                db.SaveChanges();
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