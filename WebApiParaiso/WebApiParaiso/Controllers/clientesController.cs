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
    public class clientesController : ApiController
    {
        private Modelos db = new Modelos();

        // GET: api/clientes
        [HttpGet]
        public IQueryable<cliente> Getcliente()
        {
            return db.cliente;
        }

        // GET: api/clientes/5
        [HttpGet]
        [ResponseType(typeof(cliente))]
        public async Task<IHttpActionResult> Getcliente(int id)
        {
            cliente cliente = await db.cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/clientes/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcliente(int id, cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteExists(id))
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

        // POST: api/clientes
        [HttpPost]
        [ResponseType(typeof(cliente))]
        public async Task<IHttpActionResult> Postcliente(cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cliente.Add(cliente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cliente.id }, cliente);
        }

        // DELETE: api/clientes/5
        [HttpDelete]
        [ResponseType(typeof(cliente))]
        public async Task<IHttpActionResult> Deletecliente(int id)
        {
            cliente cliente = await db.cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.cliente.Remove(cliente);
            await db.SaveChangesAsync();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clienteExists(int id)
        {
            return db.cliente.Count(e => e.id == id) > 0;
        }
    }
}