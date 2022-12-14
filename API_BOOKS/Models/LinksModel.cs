using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_BOOKS.Models
{
    public class LinksModel
    {
        public LinksModel(Table_Links links)
        {
            IdLink = links.IdLink;
            Link = links.Link;
            IdBook = links.IdBook;
        }

        public int IdLink { get; set; }
        public int IdBook { get; set; }
        public string Link { get; set; }

    }
}