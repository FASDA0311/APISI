using Application.Usuario.Commands.Crear;
using Application.Usuario.Commands.Update;
using Application.Usuario.Queries.Listar;
using Application.Usuario.Queries.Obtener;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarUsuario()
        {
            try
            {
                var response = await Mediator.Send(new ListarUsuarioQuery());
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
                var response = await Mediator.Send(new ObtenerUsuarioQuery { Id = Id });
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
        public async Task<IActionResult> CrearUsuario([FromBody] CreateUsuarioCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("actualizar/{datoID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVariablePaft([FromRoute] int datoID, [FromBody] UpdateUsuarioCommand command)
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
