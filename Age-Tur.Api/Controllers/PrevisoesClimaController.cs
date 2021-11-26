using Age_Tur.Services.Modules.PrevisoesTempo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Age_Tur.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PrevisoesClimaController : ControllerBase
    {
        private readonly PrevisaoClimaService _previsaoClimaService;
        public PrevisoesClimaController(PrevisaoClimaService previsaoClimaService)
        {
            _previsaoClimaService = previsaoClimaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var empresas = await _previsaoClimaService.GetAllPrevisoesClima();
            return Ok(empresas);
        }
    }
}
