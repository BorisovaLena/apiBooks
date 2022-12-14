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
    public class Table_BooksController : ApiController
    {
        private Borisova_BooksEntities db = new Borisova_BooksEntities();

        // GET: api/Table_Books
        [ResponseType(typeof(List<BooksModel>))]
        public IHttpActionResult GetTable_Books()
        {
            return Ok(db.Table_Books.ToList().ConvertAll(x => new BooksModel(x)));
        }

        // GET: api/Table_Books/5
        [ResponseType(typeof(Table_Books))]
        public IHttpActionResult GetTable_Books(int id)
        {
            Table_Books table_Books = db.Table_Books.Find(id);
            if (table_Books == null)
            {
                return NotFound();
            }

            return Ok(table_Books);
        }

        // PUT: api/Table_Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTable_Books(int id, Table_Books table_Books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table_Books.IdBook)
            {
                return BadRequest();
            }

            db.Entry(table_Books).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table_BooksExists(id))
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

        // POST: api/Table_Books
        [ResponseType(typeof(Table_Books))]
        public IHttpActionResult PostTable_Books(Table_Books table_Books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Table_Books.Add(table_Books);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = table_Books.IdBook }, table_Books);
        }

        // DELETE: api/Table_Books/5
        [ResponseType(typeof(Table_Books))]
        public IHttpActionResult DeleteTable_Books(int id)
        {
            Table_Books table_Books = db.Table_Books.Find(id);
            if (table_Books == null)
            {
                return NotFound();
            }

            db.Table_Books.Remove(table_Books);
            db.SaveChanges();

            return Ok(table_Books);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Table_BooksExists(int id)
        {
            return db.Table_Books.Count(e => e.IdBook == id) > 0;
        }
    }
}