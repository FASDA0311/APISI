using Application.Equipo.Queries.Listar;
using Application.Responsable.Queries.Listar;
using Microsoft.AspNetCore.Mvc;
using SistemaInformatico.API.Controllers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarResponsable()
        {
            try
            {
                var response = await Mediator.Send(new ListarResponsableQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
