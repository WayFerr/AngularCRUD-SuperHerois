using SuperHeroisApi.Application.DTOs.Request;
using SuperHeroisApi.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Application.Interfaces
{
    public interface IHeroiService
    {
        Task<HeroiResponse> ObterPorId(int id, CancellationToken cancellationToken);
        Task<List<HeroiResponse>> ObterTodos(CancellationToken cancellationToken);
        Task<List<SuperpoderResponse>> ObterTodosSuperpoderes(CancellationToken cancellationToken);
        Task<HeroiResponse> Cadastro(HeroiRequest request, CancellationToken cancellationToken);
        Task<HeroiResponse> Update(int id, HeroiRequest request, CancellationToken cancellationToken);
        Task<HeroiResponse> Delete(int id, CancellationToken cancellationToken);
    }
}
