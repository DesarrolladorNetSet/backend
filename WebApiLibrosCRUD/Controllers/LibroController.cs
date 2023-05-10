using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLibrosCRUD.Data.Repositories;
using WebApiLibrosCRUD.Model;
namespace WebApiLibrosCRUD.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]    
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;

        public LibroController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;

        }

        [HttpGet]
        [Route("getAllBooks")]
        public async Task<IActionResult> getAllBooks()
        {
            return Ok(await _libroRepository.ObtenerTodosLosLibros());
        }

        [HttpGet]
        [Route("getBookDetails")]
        public async Task<IActionResult> getBookDetails(int id)
        {
            return Ok(await _libroRepository.ObtenerDetalleDeLibro(id));
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook(Libro libro)
        {
            if (libro == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var created = await _libroRepository.InsertarLibro(libro);

            return Created("Libro guardado exitosamente", created);


        }

        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Libro libro)
        {
            if (libro == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _libroRepository.ActualizarLibro(libro);

            return NoContent();


        }

        [HttpDelete]
        [Route("DeleteBook")]
        [EnableCors]
        public async Task<IActionResult> DeleteBook(int id)
        {

            await _libroRepository.BorrarLibro(id);
            return NoContent();


        }

    }
}
