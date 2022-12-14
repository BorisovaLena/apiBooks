using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_BOOKS.Models
{
    public class AuthorsModel
    {
        public AuthorsModel(Table_Authors authors)
        {
            IdAuthor = authors.IdAuthor;
            NameAuthor = authors.NameAuthor;
        }
        public int IdAuthor { get; set; }
        public string NameAuthor { get; set; }
    }
}