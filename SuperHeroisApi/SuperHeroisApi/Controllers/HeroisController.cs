using Microsoft.AspNetCore.Mvc;
using SuperHeroisApi.Application.DTOs.Request;
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

        [HttpPost]
        public async Task<IActionResult> Cadastro([FromBody] HeroiRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var heroi = await _heroiService.Cadastro(request, cancellationToken);

            return new CreatedAtRouteResult("ObterHeroiPorId", new { id = heroi.Id }, heroi);
        }
    }
}
