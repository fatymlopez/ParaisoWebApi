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
using WebApiParaiso.Models;

namespace WebApiParaiso.Areas.HelpPage.Controllers
{
    public class detallereservacionssController : ApiController
    {
        private ModeloDB db = new ModeloDB();

        // GET: api/detallereservacionss
        [HttpGet]
        public IQueryable<detallereservacion> Getdetallereservacion()
        {
            return db.detallereservacion;
        }

        // GET: api/detallereservacionss/5
        [HttpGet]
        [ResponseType(typeof(detallereservacion))]
        public async Task<IHttpActionResult> Getdetallereservacion(int id)
        {
            detallereservacion detallereservacion = await db.detallereservacion.FindAsync(id);
            if (detallereservacion == null)
            {
                return NotFound();
            }

            return Ok(detallereservacion);
        }

        // PUT: api/detallereservacionss/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdetallereservacion(int id, detallereservacion detallereservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallereservacion.idreservacion)
            {
                return BadRequest();
            }

            db.Entry(detallereservacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!detallereservacionExists(id))
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

        // POST: api/detallereservacionss
        [HttpPost]
        [ResponseType(typeof(detallereservacion))]
        public async Task<IHttpActionResult> Postdetallereservacion(detallereservacion detallereservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.detallereservacion.Add(detallereservacion);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (detallereservacionExists(detallereservacion.idreservacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = detallereservacion.idreservacion }, detallereservacion);
        }

        // DELETE: api/detallereservacionss/5
        [HttpDelete]
        [ResponseType(typeof(detallereservacion))]
        public async Task<IHttpActionResult> Deletedetallereservacion(int id)
        {
            detallereservacion detallereservacion = await db.detallereservacion.FindAsync(id);
            if (detallereservacion == null)
            {
                return NotFound();
            }

            db.detallereservacion.Remove(detallereservacion);
            await db.SaveChangesAsync();

            return Ok(detallereservacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool detallereservacionExists(int id)
        {
            return db.detallereservacion.Count(e => e.idreservacion == id) > 0;
        }
    }
}