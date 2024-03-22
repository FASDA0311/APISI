using Application.Ambiente.Commands.CrearAmbiente;
using Application.Ambiente.Queries;
using Application.PersonalSoporte.Commands.CrearPersonaSoporte;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbienteController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarAmbiente()
        {
            try
            {
                var response = await Mediator.Send(new ListarAmbienteQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("agregar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CrearAmbiente([FromBody] CreateAmbienteCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}