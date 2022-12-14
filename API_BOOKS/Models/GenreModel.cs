using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_BOOKS.Models
{
    public class GenreModel
    {
        public GenreModel(Table_Genres genres)
        {
            IdGenre = genres.IdGenre;
            TitleGenre = genres.TitleGenre;
        }

        public int IdGenre { get; set; }
        public string TitleGenre { get; set; }
    }
}