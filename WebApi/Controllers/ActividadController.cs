using Application.Actividad.Commands.Crear;
using Application.Actividad.Commands.Update;
using Application.Actividad.Queries.Listar;
using Application.Actividad.Queries.Obtener;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarActividad()
        {
            try
            {
                var response = await Mediator.Send(new ListarActividadQuery());
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
                var response = await Mediator.Send(new ObtenerActividadQuery { Id = Id });
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
        public async Task<IActionResult> CrearActividad([FromBody] CreateActividadCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("actualizar/{datoID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVariablePaft([FromRoute] int datoID, [FromBody] UpdateActividadCommand command)
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

