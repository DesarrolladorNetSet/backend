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
    public class AutorRepository : IAutorRepository
    {
        Data.MySqlConfiguration _connectionString;
        public AutorRepository(Data.MySqlConfiguration connectionString )
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnetionString);
        }

        public async Task<bool> ActualizarAutor(Autor autor)
        {
            var db = dbConnection();
            var sql = @"
                update  Autor set nombre =  @Nombre
                where id = @Id
                  ";

            var result = await db.ExecuteAsync(sql, new { autor.nombre, autor.id });
            return result > 0;

        }

        public async Task<bool> BorrarAutor(int id)
        {
            var db = dbConnection();
            var sql = @"
                delete 
                from Autor
                where id = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<bool> InsertarAutor(Autor autor)
        {
            var db = dbConnection();
            var sql = @"
                insert into Autor (nombre) 
                values(@Nombre)";

            var result = await db.ExecuteAsync(sql, new { autor.nombre });
            return result > 0;
        }

        public async Task<Autor> ObtenerDetalleDeAutor(int id)
        {
            var db = dbConnection(); 
            var sql = @"
                Select id, nombre 
                from Autor
                where id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Autor>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Autor>> ObtenerTodosLosAutores()
        {
            var db = dbConnection();
            var sql = @"
                Select id, nombre 
                from Autor
                ";
            return await db.QueryAsync<Autor>(sql, new { });
        }



    }
}
