using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_BOOKS;
using API_BOOKS.Models;

namespace API_BOOKS.Controllers
{
    public class Table_LinksController : ApiController
    {
        private Borisova_BooksEntities db = new Borisova_BooksEntities();

        // GET: api/Table_Links
        [ResponseType(typeof(List<LinksModel>))]
        public IHttpActionResult GetTable_Links()
        {
            return Ok(db.Table_Links.ToList().ConvertAll(x => new LinksModel(x)));
        }

        // GET: api/Table_Links/5
        [ResponseType(typeof(Table_Links))]
        public IHttpActionResult GetTable_Links(int id)
        {
            Table_Links table_Links = db.Table_Links.Find(id);
            if (table_Links == null)
            {
                return NotFound();
            }

            return Ok(table_Links);
        }

        // PUT: api/Table_Links/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTable_Links(int id, Table_Links table_Links)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table_Links.IdLink)
            {
                return BadRequest();
            }

            db.Entry(table_Links).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table_LinksExists(id))
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

        // POST: api/Table_Links
        [ResponseType(typeof(Table_Links))]
        public IHttpActionResult PostTable_Links(Table_Links table_Links)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Table_Links.Add(table_Links);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = table_Links.IdLink }, table_Links);
        }

        // DELETE: api/Table_Links/5
        [ResponseType(typeof(Table_Links))]
        public IHttpActionResult DeleteTable_Links(int id)
        {
            Table_Links table_Links = db.Table_Links.Find(id);
            if (table_Links == null)
            {
                return NotFound();
            }

            db.Table_Links.Remove(table_Links);
            db.SaveChanges();

            return Ok(table_Links);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Table_LinksExists(int id)
        {
            return db.Table_Links.Count(e => e.IdLink == id) > 0;
        }
    }
}