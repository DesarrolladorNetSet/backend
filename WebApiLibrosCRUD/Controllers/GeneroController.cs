using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLibrosCRUD.Model;
using WebApiLibrosCRUD.Data.Repositories;

namespace WebApiGenerosCRUD.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;

        }

        [HttpGet]
        [Route("getAllGenre")]
        public async Task<IActionResult> getAllGenre()
        {
            return Ok(await _generoRepository.ObtenerTodosLosGeneros());
        }


        [HttpGet]
        [Route("getGenreDetails")]
        public async Task<IActionResult> getGenreDetails(int id)
        {
            return Ok(await _generoRepository.ObtenerDetalleDeGenero(id));
        }

        [HttpPost]
        [Route("CreateGenre")]
        public async Task<IActionResult> CreateGenre(Genero Genero)
        {
            if (Genero == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var created = await _generoRepository.InsertarGenero(Genero);

            return Created("Genero guardado exitosamente", created);


        }

        [HttpPut]
        [Route("UpdateGenre")]
        public async Task<IActionResult> UpdateGenre(Genero Genero)
        {
            if (Genero == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _generoRepository.ActualizarGenero(Genero);

            return NoContent();


        }

        [HttpDelete]
        [Route("DeleteGenre")]
        public async Task<IActionResult> DeleteGenre(int id)
        {

            await _generoRepository.BorrarGenero(id);
            return NoContent();


        }

    }
}
