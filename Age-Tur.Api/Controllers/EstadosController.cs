using Age_Tur.Services.Modules.Estados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Age_Tur.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EstadosController : ControllerBase
    {
        private readonly EstadoService _estadoService;
        public EstadosController(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var estados = await _estadoService.GetAllEstados();
            return Ok(estados);
        }
    }
}
