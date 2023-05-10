using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrosCRUD.Model;

namespace WebApiLibrosCRUD.Data.Repositories
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> ObtenerTodosLosAutores();

        Task<Autor> ObtenerDetalleDeAutor(int id);

        Task<bool> InsertarAutor(Autor autor);

        Task<bool> ActualizarAutor(Autor autor);

        Task<bool> BorrarAutor(int id);
    }
}
