using JDBEBIDASAPI.Model;
using JDBEBIDASAPI.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDBEBIDASAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidasController : ControllerBase
    {
        private readonly IBebidaRepositorio _bebidaRepositorio;
        public BebidasController(IBebidaRepositorio bebidaRepositorio)
        {
            _bebidaRepositorio = bebidaRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Bebida>> GetBebidas()
        {
            return await _bebidaRepositorio.Get();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Bebida>> GetBebidas(int Id)
        {
            return await _bebidaRepositorio.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Bebida>> PostBebidas([FromBody] Bebida bebida)
        {
            var newBebida = await _bebidaRepositorio.Create(bebida);
            return CreatedAtAction(nameof(GetBebidas), new { Id = newBebida.Id }, newBebida);
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete(int Id)
        {
            var bebidaToDelete = await _bebidaRepositorio.Get(Id);

            if (bebidaToDelete == null)
                return NotFound();

            await _bebidaRepositorio.Delete(bebidaToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutBebidas(int Id, [FromBody] Bebida bebida)
        {
            if (Id != bebida.Id)
                return BadRequest();

            await _bebidaRepositorio.Update(bebida);

            return NoContent();
        }
    }
}
