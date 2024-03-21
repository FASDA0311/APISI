using Application.PersonalSoporte.Queries;
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
    }
}
