using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLibrosCRUD.Model
{
    public class Libro
    {
        public int id { get; set; }
        public string title { get; set; }

        public string author { get; set; }
        public Autor autor { get; set; }
        public Genero genero { get; set; }

        public string genre { get; set; }
        public string summary { get; set; }
        public string Image { get; set; }
        public string publicationDate { get; set; }
        public string language { get; set; }
        public string Relevance { get; set; }

    }
}
