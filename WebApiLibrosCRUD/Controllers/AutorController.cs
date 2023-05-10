using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLibrosCRUD.Data.Repositories;
using WebApiLibrosCRUD.Model;
namespace WebApiLibrosCRUD.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
            
        }

        [HttpGet]
        [Route("getAllAuthors")]
        public async Task<IActionResult> getAllAuthors()
        {
            return Ok(await _autorRepository.ObtenerTodosLosAutores());
        }

        [HttpGet]
        [Route("getAuthorDetails")]
        public async Task<IActionResult> getAuthorDetails(int id)
        {
            return Ok(await _autorRepository.ObtenerDetalleDeAutor(id));
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(Autor autor)
        {
            if (autor == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var created = await _autorRepository.InsertarAutor(autor);

            return Created("Libro guardado exitosamente",created );


        }

        [HttpPut]
        [Route("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(Autor autor)
        {
            if (autor == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _autorRepository.ActualizarAutor(autor);

            return NoContent();


        }

        [HttpDelete]
        [Route("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {

            await _autorRepository.BorrarAutor(id);

            return NoContent();


        }
    }
}
