using Application.DetalleDocumento.Queries.Listar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaInformatico.API.Controllers;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleDocumentoController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarDetalleDocumento()
        {
            try
            {
                var response = await Mediator.Send(new ListarDetalleDocumentoQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
