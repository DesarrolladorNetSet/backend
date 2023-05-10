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
    public class GeneroRepository : IGeneroRepository
    {
        Data.MySqlConfiguration _connectionString;
        public GeneroRepository(Data.MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnetionString);
        }

        public async Task<bool> ActualizarGenero(Genero genero)
        {
            var db = dbConnection();
            var sql = @"
                update  Genero set descripcion =  @Descripcion
                where id = @Id
                  ";

            var result = await db.ExecuteAsync(sql, new { genero.descripcion, genero.id });
            return result > 0;
        }

        public async Task<bool> BorrarGenero(int id)
        {
            var db = dbConnection();
            var sql = @"
                delete 
                from Genero
                where id = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<bool> InsertarGenero(Genero genero)
        {
            var db = dbConnection();
            var sql = @"
                insert into Genero (descripcion) 
                values(@Nombre)";

            var result = await db.ExecuteAsync(sql, new { genero.descripcion });
            return result > 0;

        }

        public async Task<Genero> ObtenerDetalleDeGenero(int id)
        {
            var db = dbConnection();
            var sql = @"
                Select id, descripcion 
                from Genero
                where id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Genero>(sql, new { Id = id });

        }

        public async Task<IEnumerable<Genero>> ObtenerTodosLosGeneros()
        {
            var db = dbConnection();
            var sql = @"
                Select id, descripcion 
                from Genero
                ";
            return await db.QueryAsync<Genero>(sql, new { });
        }



    }
}
