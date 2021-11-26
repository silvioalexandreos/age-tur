using Age_Tur.Services.Modules.Cidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Age_Tur.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CidadesController : ControllerBase
    {
        private readonly CidadeService _cidadeService;
        public CidadesController(CidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var cidades = _cidadeService.GetAllCidades();
            return Ok(cidades);
        }
    }
}
