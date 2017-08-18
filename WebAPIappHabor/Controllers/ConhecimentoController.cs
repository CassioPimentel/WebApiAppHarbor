using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAPIappHabor.Models;

namespace WebAPIappHabor.Controllers
{
    [EnableCors(origins:"*", headers: "*", methods: "*")]
    public class ConhecimentoController : ApiController
    {
        private Context db = new Context();

        public IQueryable<Conhecimento> GetConhecimento()
        {
            return db.Conhecimento;
        }

        [ResponseType(typeof(Conhecimento))]
        public IHttpActionResult GetConhecimento(int id)
        {
            Conhecimento conhecimento = db.Conhecimento.Find(id);
            if (conhecimento == null)
            {
                return NotFound();
            }

            return Ok(conhecimento);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutConhecimento(int id, Conhecimento conhecimento)
        {
            if (conhecimento == null)
            {
                return BadRequest(ModelState);
            }

            if (id != conhecimento.ID)
            {
                return BadRequest();
            }

            db.Entry(conhecimento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        [ResponseType(typeof(Conhecimento))]
        public IHttpActionResult PostConhecimento(Conhecimento conhecimento)
        {
            if (conhecimento == null)
            {
                return BadRequest(ModelState);
            }

            //conhecimento.Profissional_Conhecimento = null;
            
            db.Conhecimento.Add(conhecimento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = conhecimento.ID }, conhecimento);
        }

        [ResponseType(typeof(Conhecimento))]
        public IHttpActionResult DeleteConhecimento(int id)
        {
            Conhecimento conhecimento = db.Conhecimento.Find(id);
            if (conhecimento == null)
            {
                return NotFound();
            }

            db.Conhecimento.Remove(conhecimento);
            db.SaveChanges();

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
            return db.Conhecimento.Count(e => e.ID == id) > 0;
        }
    }
}