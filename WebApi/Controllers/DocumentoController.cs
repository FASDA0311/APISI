using Application.Documento.Queries.Listar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaInformatico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : AbstractController
    {
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarDocumento()
        {
            try
            {
                var response = await Mediator.Send(new ListarDocumentoQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
