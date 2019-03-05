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
    public class ventashesController : ApiController
    {
        private Modelos db = new Modelos();

        // GET: api/ventashes
        [HttpGet]
        public IQueryable<ventash> Getventash()
        {
            return db.ventash;
        }

        // GET: api/ventashes/5
        [HttpGet]
        [ResponseType(typeof(ventash))]
        public async Task<IHttpActionResult> Getventash(int id)
        {
            ventash ventash = await db.ventash.FindAsync(id);
            if (ventash == null)
            {
                return NotFound();
            }

            return Ok(ventash);
        }

        // PUT: api/ventashes/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putventash(int id, ventash ventash)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ventash.id)
            {
                return BadRequest();
            }

            db.Entry(ventash).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ventashExists(id))
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

        // POST: api/ventashes
        [HttpPost]
        [ResponseType(typeof(ventash))]
        public async Task<IHttpActionResult> Postventash(ventash ventash)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ventash.Add(ventash);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ventash.id }, ventash);
        }

        // DELETE: api/ventashes/5
        [HttpDelete]
        [ResponseType(typeof(ventash))]
        public async Task<IHttpActionResult> Deleteventash(int id)
        {
            ventash ventash = await db.ventash.FindAsync(id);
            if (ventash == null)
            {
                return NotFound();
            }

            db.ventash.Remove(ventash);
            await db.SaveChangesAsync();

            return Ok(ventash);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ventashExists(int id)
        {
            return db.ventash.Count(e => e.id == id) > 0;
        }
    }
}