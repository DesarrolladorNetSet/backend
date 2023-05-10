using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrosCRUD.Model;

namespace WebApiLibrosCRUD.Data.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        Data.MySqlConfiguration _connectionString;
        public LibroRepository(Data.MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnetionString);
        }

        public async Task<bool> ActualizarLibro(Libro libro)
        {
            var db = dbConnection();
            var sql = @"
                update  Libro set title =  @Title, image = @Image, summary = @Summary, publicationDate = @PublicationDate, lenguaje = @Language, relevance = @Relevance
                where id = @Id
                  ";

            var result = await db.ExecuteAsync(sql, new { libro.title, libro.Image, libro.summary, libro.publicationDate, libro.language, libro.Relevance, libro.id });
            return result > 0;
        }

        public async Task<bool> BorrarLibro(int id)
        {
            var db = dbConnection();
            var sql = @"
                delete 
                from Libro
                where id = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<bool> InsertarLibro(Libro libro)
        {
            var db = dbConnection();
            var sql = @"
                insert into Libro (title, idGenero, idAutor, Image, summary, publicationDate, lenguaje, relevance) 
                values(@Nombre, @IdGenero, @IdAutor, @LigaImagen, @Resumen, @FechaPublicacion, @Lenguaje, @Relevance)";

            var result = await db.ExecuteAsync(sql, new { @Nombre = libro.title, IdGenero = libro.genero.id, @IdAutor = libro.autor.id, @LigaImagen= libro.Image, @Resumen = libro.summary, @FechaPublicacion = libro.publicationDate, @Lenguaje = libro.language, libro.Relevance });

            return result > 0;

        }

        public async Task<Libro> ObtenerDetalleDeLibro(int id)
        {
            var db = dbConnection();
            var sql = @"
                Select l.id, l.title, l.Image, l.summary, l.idAutor , a.nombre as author, l.idGenero, g.descripcion as genre, l.publicationDate, l.lenguaje as language, l.Relevance
                from Libro l
                left join Autor a on a.id = l.idAutor
                left join Genero g on g.id = l.idGenero
                where l.id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Libro>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Libro>> ObtenerTodosLosLibros()
        {
            /*
            List<Libro> _resultado = new List<Libro>();
            Libro _libro1 = new Libro();
            _libro1.title = "La Metamorfosis";
            _libro1.summary = "Un hombre se despierta un día para descubrir que se ha transformado en un insecto";
            _libro1.autor = new Autor();
            _libro1.autor.id = 1; 
            _libro1.author = "Franz Kafka";
            _libro1.autor.nombre = "Franz Kafka";
            _libro1.genero = new Genero();
            _libro1.genero.id = 1;
            _libro1.genre  = "romance";
            _libro1.genero.descripcion = "romance";
            _libro1.Image = "./images/portada_image.jpeg";
            _libro1.publicationDate = "1915";
            _libro1.language = "Español";
            _libro1.Relevance = "1";


            Libro _libro2 = new Libro();
            _libro2.title = "El Gran Gatsby";
            _libro2.summary = "Un hombre rico intenta recuperar a su amor de juventud mientras enfrenta los desafíos de la vida en los años 20";
            _libro2.autor = new Autor();
            _libro2.author = "F. Scott Fitzgerald";
            _libro2.autor.id = 2;
            _libro2.autor.nombre = "F. Scott Fitzgerald";
            _libro2.genero = new Genero(); 
            _libro2.genero.id = 2;
            _libro2.genre = "ficción";
            _libro2.genero.descripcion = "ficción";
            _libro2.Image = "./images/portada2.jpeg";
            _libro2.publicationDate = "1925";
            _libro2.language = "Inglés";
            _libro2.Relevance = "2";

            Libro _libro3 = new Libro();
            _libro3.title = "1984";
            _libro3.summary = "En un futuro distópico, un hombre lucha contra un gobierno opresivo que controla todos los aspectos de la vida.";
            _libro3.autor = new Autor();
            _libro3.autor.id = 3;
            _libro3.author = "George Orwell";
            _libro3.autor.nombre = "George Orwell";
            _libro3.genero = new Genero();
            _libro3.genero.id = 2;
            _libro3.genre = "ficción";
            _libro3.genero.descripcion = "ficción";
            _libro3.Image = "./images/images.jpg";
            _libro3.publicationDate = "1949";
            _libro3.language = "Francés";
            _libro3.Relevance = "2";

            _resultado.Add(_libro1);
            _resultado.Add(_libro2);
            _resultado.Add(_libro3);

            return _resultado;
            */
            
            var db = dbConnection();
            var sql = @"
                Select l.id, l.title, l.Image, l.summary, l.idAutor , a.nombre as author, l.idGenero, g.descripcion as genre, l.publicationDate, l.lenguaje as language, l.Relevance
                from Libro l
                left join Autor a on a.id = l.idAutor
                left join Genero g on g.id = l.idGenero
                ";
            return await db.QueryAsync<Libro>(sql, new { });
            
        }


    }
}
