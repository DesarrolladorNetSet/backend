using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrosCRUD.Model;

namespace WebApiLibrosCRUD.Data.Repositories
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> ObtenerTodosLosGeneros();

        Task<Genero> ObtenerDetalleDeGenero(int id);

        Task<bool> InsertarGenero(Genero genero);

        Task<bool> ActualizarGenero(Genero genero);

        Task<bool> BorrarGenero(int id);
    }
}
