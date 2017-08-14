using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult GetProfissional_Conhecimento(int id)
        {
            Profissional_Conhecimento profissional_Conhecimento = db.Profissional_Conhecimento.Find(id);
            if (profissional_Conhecimento == null)
            {
                return NotFound();
            }

            return Ok(profissional_Conhecimento);
        }

        // PUT: api/Profissional_Conhecimento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfissional_Conhecimento(int id, Profissional_Conhecimento profissional_Conhecimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profissional_Conhecimento.ID)
            {
                return BadRequest();
            }

            db.Entry(profissional_Conhecimento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult PostProfissional_Conhecimento(Profissional_Conhecimento profissional_Conhecimento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Profissional = db.Profissional.Where(x => x.ID == profissional_Conhecimento.Profissional_ID).FirstOrDefault();
                var Conhecimento = db.Conhecimento.Where(x => x.ID == profissional_Conhecimento.Conhecimento_ID).FirstOrDefault();

                profissional_Conhecimento.Profissional = Profissional;
                profissional_Conhecimento.Conhecimento = Conhecimento;

                db.Profissional_Conhecimento.Add(profissional_Conhecimento);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = profissional_Conhecimento.ID }, profissional_Conhecimento);

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }    
        }

        // DELETE: api/Profissional_Conhecimento/5
        [ResponseType(typeof(Profissional_Conhecimento))]
        public IHttpActionResult DeleteProfissional_Conhecimento(int id)
        {
            Profissional_Conhecimento profissional_Conhecimento = db.Profissional_Conhecimento.Find(id);
            if (profissional_Conhecimento == null)
            {
                return NotFound();
            }

            db.Profissional_Conhecimento.Remove(profissional_Conhecimento);
            db.SaveChanges();

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
            return db.Profissional_Conhecimento.Count(e => e.ID == id) > 0;
        }
    }
}