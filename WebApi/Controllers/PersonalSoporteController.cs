using Application.PersonalSoporte.Commands.CrearPersonaSoporte;
using Application.PersonalSoporte.Commands.UpdatePersonaSoporte;
using Application.PersonalSoporte.Queries;
using Application.PersonalSoporte.Queries.ObtenerPersonaSoporte;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalSoporteController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarPersonalSoporte()
        {
            try
            {
                var response = await Mediator.Send(new ListarPersonaSoporteQuery());
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
                var response = await Mediator.Send(new ObtenerPersonalSoporteQuery { Id = Id });
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
        public async Task<IActionResult> CrearPersonalSoporte([FromBody] CreatePersonalSoporteCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("actualizar/{datoID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVariablePaft([FromRoute] int datoID, [FromBody] UpdatePersonalSoporteCommand command)
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
