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
    public class Table_AuthorsController : ApiController
    {
        private Borisova_BooksEntities db = new Borisova_BooksEntities();

        // GET: api/Table_Authors
        [ResponseType(typeof(List<AuthorsModel>))]
        public IHttpActionResult GetTable_Authors()
        {
            return Ok(db.Table_Authors.ToList().ConvertAll(x => new AuthorsModel(x)));
        }

        // GET: api/Table_Authors/5
        [ResponseType(typeof(Table_Authors))]
        public IHttpActionResult GetTable_Authors(int id)
        {
            Table_Authors table_Authors = db.Table_Authors.Find(id);
            if (table_Authors == null)
            {
                return NotFound();
            }

            return Ok(table_Authors);
        }

        // PUT: api/Table_Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTable_Authors(int id, Table_Authors table_Authors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table_Authors.IdAuthor)
            {
                return BadRequest();
            }

            db.Entry(table_Authors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table_AuthorsExists(id))
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

        // POST: api/Table_Authors
        [ResponseType(typeof(Table_Authors))]
        public IHttpActionResult PostTable_Authors(Table_Authors table_Authors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Table_Authors.Add(table_Authors);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = table_Authors.IdAuthor }, table_Authors);
        }

        // DELETE: api/Table_Authors/5
        [ResponseType(typeof(Table_Authors))]
        public IHttpActionResult DeleteTable_Authors(int id)
        {
            Table_Authors table_Authors = db.Table_Authors.Find(id);
            if (table_Authors == null)
            {
                return NotFound();
            }

            db.Table_Authors.Remove(table_Authors);
            db.SaveChanges();

            return Ok(table_Authors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Table_AuthorsExists(int id)
        {
            return db.Table_Authors.Count(e => e.IdAuthor == id) > 0;
        }
    }
}