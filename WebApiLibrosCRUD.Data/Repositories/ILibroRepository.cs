using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrosCRUD.Model;

namespace WebApiLibrosCRUD.Data.Repositories
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> ObtenerTodosLosLibros();

        Task<Libro> ObtenerDetalleDeLibro(int id);

        Task<bool> InsertarLibro(Libro libro);

        Task<bool> ActualizarLibro(Libro libro);

        Task<bool> BorrarLibro(int id);
    }
}
