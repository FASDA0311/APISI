using Application.Entrada.Commands.Crear;
using Application.Entrada.Commands.Update;
using Application.Entrada.Queries.Listar;
using Application.Entrada.Queries.Obtener;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarEntrada()
        {
            try
            {
                var response = await Mediator.Send(new ListarEntradaQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerSegmentacion([FromRoute] int Id)
        {

            try
            {
                var response = await Mediator.Send(new ObtenerEntradaQuery { Id = Id });
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
        public async Task<IActionResult> CrearEntrada([FromBody] CreateEntradaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("actualizar/{datoID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVariablePaft([FromRoute] int datoID, [FromBody] UpdateEntradaCommand command)
        {

            try
            {
                if (datoID != command.Codigo)
                {
                    return BadRequest("Los identificadores son diferentes");
                }

                var response = await Mediator.Send(command);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
