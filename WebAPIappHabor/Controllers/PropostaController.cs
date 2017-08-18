using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIappHabor.Models;

namespace WebAPIappHabor.Controllers
{
    public class PropostaController : ApiController
    {
        private Context db = new Context();

        public IQueryable<Proposta> GetProposta()
        {
            return db.Proposta;
        }

        [Route("GetPropostaPorProfissional")]
        [ResponseType(typeof(Proposta))]
        public IHttpActionResult GetPropostaPorProfissional(int id)
        {
            List<Proposta> proposta = db.Proposta.Where(x => x.Profissional_ID == id).ToList();

            if (proposta == null)
            {
                return NotFound();
            }

            return Ok(proposta);
        }

        [Route("GetPropostaPorEmpresa")]
        [ResponseType(typeof(Proposta))]
        public IHttpActionResult GetPropostaPorEmpresa(int id)
        {
            List<Proposta> proposta = db.Proposta.Where(x => x.Empresa_ID == id).ToList();

            if (proposta == null)
            {
                return NotFound();
            }

            return Ok(proposta);
        }

        [Route("GetPropostaAceitaPorEmpresa")]
        [ResponseType(typeof(Proposta))]
        public IHttpActionResult GetPropostaAceitaPorEmpresa(int id)
        {
            List<Proposta> proposta = db.Proposta.Where(x => x.Empresa_ID == id && x.Status == true).ToList();

            if (proposta == null)
            {
                return NotFound();
            }

            return Ok(proposta);
        }

        [Route("GetPropostaAceitaPorProfissional")]
        [ResponseType(typeof(Proposta))]
        public IHttpActionResult GetPropostaAceitaPorProfissional(int id)
        {
            List<Proposta> proposta = db.Proposta.Where(x => x.Profissional_ID == id && x.Status == true).ToList();

            if (proposta == null)
            {
                return NotFound();
            }

            return Ok(proposta);
        }

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

        [ResponseType(typeof(void))]
        public IHttpActionResult PutProposta(int id, Proposta proposta)
        {
            if (proposta == null)
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

        [ResponseType(typeof(Proposta))]
        public IHttpActionResult PostProposta(Proposta proposta)
        {
            if (proposta == null)
            {
                return BadRequest(ModelState);
            }

            var Profissional = db.Profissional.Where(x => x.ID == proposta.Profissional_ID).FirstOrDefault();

            if (Profissional == null)
            {
                return BadRequest("Profissional não encontrado.");
            }

            var Empresa = db.Empresa.Where(x => x.ID == proposta.Empresa_ID).FirstOrDefault();

            if (Empresa == null)
            {
                return BadRequest("Empresa não encontrado.");
            }

            proposta.Profissional = Profissional;
            proposta.Empresa = Empresa;
            
            db.Proposta.Add(proposta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proposta.ID }, proposta);
        }

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