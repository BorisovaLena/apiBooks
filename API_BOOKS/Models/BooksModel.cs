using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_BOOKS.Models
{
    public class BooksModel
    {
        public BooksModel(Table_Books books)
        {
            IdBook = books.IdBook;
            TitleBook = books.TitleBook;
            Annitation = books.Annotation;
            Summary = books.Summary;
            Image = books.Image;
            IdAuthor = (int)books.IdAuthor;
            IdGenre = (int)books.IdGenre;
        }
        public int IdBook { get; set; }
        public string TitleBook { get; set; }
        public string Annitation { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public int IdAuthor { get; set; }
        public int IdGenre { get; set; }
    }
}