using Application.Equipo.Queries.Listar;

using Microsoft.AspNetCore.Mvc;
using SistemaInformatico.API.Controllers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarEquipo()
        {
            try
            {
                var response = await Mediator.Send(new ListarEquipoQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
