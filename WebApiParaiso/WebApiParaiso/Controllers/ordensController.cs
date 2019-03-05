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

namespace WebApiParaiso.Controllers
{
    public class ordensController : ApiController
    {
        private Modelos db = new Modelos();

        // GET: api/ordens
        [HttpGet]
        public IQueryable<orden> Getorden()
        {
            return db.orden;
        }

        // GET: api/ordens/5
        [HttpGet]
        [ResponseType(typeof(orden))]
        public async Task<IHttpActionResult> Getorden(int id)
        {
            orden orden = await db.orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            return Ok(orden);
        }

        // PUT: api/ordens/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putorden(int id, orden orden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orden.id)
            {
                return BadRequest();
            }

            db.Entry(orden).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ordenExists(id))
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

        // POST: api/ordens
        [HttpPost]
        [ResponseType(typeof(orden))]
        public async Task<IHttpActionResult> Postorden(orden orden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.orden.Add(orden);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orden.id }, orden);
        }

        // DELETE: api/ordens/5
        [HttpDelete]
        [ResponseType(typeof(orden))]
        public async Task<IHttpActionResult> Deleteorden(int id)
        {
            orden orden = await db.orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            db.orden.Remove(orden);
            await db.SaveChangesAsync();

            return Ok(orden);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ordenExists(int id)
        {
            return db.orden.Count(e => e.id == id) > 0;
        }
    }
}