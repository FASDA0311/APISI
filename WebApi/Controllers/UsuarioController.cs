using Application.Usuario.Queries.Listar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaInformatico.API.Controllers;

namespace WebApi.Controllers
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
    }
}
