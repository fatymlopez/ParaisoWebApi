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
    public class menusController : ApiController
    {
        private Modelos db = new Modelos();

        // GET: api/menus
        [HttpGet]
        public IQueryable<menu> Getmenu()
        {
            return db.menu;
        }

        // GET: api/menus/5
        [HttpGet]
        [ResponseType(typeof(menu))]
        public async Task<IHttpActionResult> Getmenu(int id)
        {
            menu menu = await db.menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        // PUT: api/menus/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmenu(int id, menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.id)
            {
                return BadRequest();
            }

            db.Entry(menu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!menuExists(id))
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

        // POST: api/menus
        [HttpPost]
        [ResponseType(typeof(menu))]
        public async Task<IHttpActionResult> Postmenu(menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.menu.Add(menu);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = menu.id }, menu);
        }

        // DELETE: api/menus/5
        [HttpDelete]
        [ResponseType(typeof(menu))]
        public async Task<IHttpActionResult> Deletemenu(int id)
        {
            menu menu = await db.menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            db.menu.Remove(menu);
            await db.SaveChangesAsync();

            return Ok(menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool menuExists(int id)
        {
            return db.menu.Count(e => e.id == id) > 0;
        }
    }
}