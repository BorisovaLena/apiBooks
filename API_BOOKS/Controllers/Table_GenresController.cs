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
    public class Table_GenresController : ApiController
    {
        private Borisova_BooksEntities db = new Borisova_BooksEntities();

        // GET: api/Table_Genres
        [ResponseType(typeof(List<GenreModel>))]
        public IHttpActionResult GetTable_Genres()
        {
            return Ok(db.Table_Genres.ToList().ConvertAll(x => new GenreModel(x)));
        }

        // GET: api/Table_Genres/5
        [ResponseType(typeof(Table_Genres))]
        public IHttpActionResult GetTable_Genres(int id)
        {
            Table_Genres table_Genres = db.Table_Genres.Find(id);
            if (table_Genres == null)
            {
                return NotFound();
            }

            return Ok(table_Genres);
        }

        // PUT: api/Table_Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTable_Genres(int id, Table_Genres table_Genres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table_Genres.IdGenre)
            {
                return BadRequest();
            }

            db.Entry(table_Genres).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table_GenresExists(id))
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

        // POST: api/Table_Genres
        [ResponseType(typeof(Table_Genres))]
        public IHttpActionResult PostTable_Genres(Table_Genres table_Genres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Table_Genres.Add(table_Genres);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = table_Genres.IdGenre }, table_Genres);
        }

        // DELETE: api/Table_Genres/5
        [ResponseType(typeof(Table_Genres))]
        public IHttpActionResult DeleteTable_Genres(int id)
        {
            Table_Genres table_Genres = db.Table_Genres.Find(id);
            if (table_Genres == null)
            {
                return NotFound();
            }

            db.Table_Genres.Remove(table_Genres);
            db.SaveChanges();

            return Ok(table_Genres);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Table_GenresExists(int id)
        {
            return db.Table_Genres.Count(e => e.IdGenre == id) > 0;
        }
    }
}