using SuperHeroisApi.Application.DTOs.Response;
using SuperHeroisApi.Application.Interfaces;
using SuperHeroisApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Application.Services
{
    public class HeroiService : IHeroiService
    {
        private readonly IHeroiRepository _heroiRepository;

        public HeroiService(IHeroiRepository heroiRepository)
        {
            _heroiRepository = heroiRepository;
        }

        public async Task<HeroiResponse> ObterPorId(int id, CancellationToken cancellationToken)
        {
            var heroi = await _heroiRepository.ObterPorId(id, cancellationToken);
            if (heroi is null) return null;

            return heroi.ToResponseModel();
        }

        public async Task<List<HeroiResponse>> ObterTodos(CancellationToken cancellationToken)
        {
            var herois = await _heroiRepository.ObterTodos(cancellationToken);

            return herois.ToResponseModel();
        }
    }
}
