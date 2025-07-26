using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroisApi.Application.Interfaces;

namespace SuperHeroisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IHeroiService _heroiService;

        public HeroisController(IHeroiService heroiService)
        {
            _heroiService = heroiService;
        }

        [HttpGet("{id}", Name = "ObterHeroiPorId")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id, CancellationToken cancellationToken)
        {
                var heroi = await _heroiService.ObterPorId(id, cancellationToken);
                if (heroi is null) return NotFound("Herói não encontrado");

                return Ok(heroi);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            var herois = await _heroiService.ObterTodos(cancellationToken);

            return Ok(herois);
        }
    }
}
