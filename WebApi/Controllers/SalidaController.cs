using Application.Salida.Commands.Crear;
using Application.Salida.Commands.Update;
using Application.Salida.Queries.Listar;
using Application.Salida.Queries.Obtener;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalidaController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarSalida()
        {
            try
            {
                var response = await Mediator.Send(new ListarSalidaQuery());
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
                var response = await Mediator.Send(new ObtenerSalidaQuery { Id = Id });
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
        public async Task<IActionResult> CrearSalida([FromBody] CreateSalidaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("actualizar/{datoID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVariablePaft([FromRoute] int datoID, [FromBody] UpdateSalidaCommand command)
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


