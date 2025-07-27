using SuperHeroisApi.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Domain.Interfaces
{
    public interface IHeroiRepository
    {
        Task<Herois> ObterPorId(int id, CancellationToken cancellationToken);
        Task<List<Herois>> ObterTodos(CancellationToken cancellationToken);
        Task<List<Superpoderes>> ObterTodosSuperpoderes(CancellationToken cancellationToken);
        Task<Herois> Cadastro(Herois heroi, CancellationToken cancellationToken);
        Task<Herois> ObterPorNomeDeHeroi(string nomeHeroi, CancellationToken cancellationToken);
        Task Update(Herois heroi, CancellationToken cancellationToken);
        Task Delete(Herois heroi, CancellationToken cancellationToken);
        Task<Herois?> ObterPorIdComSuperpoderes(int id, CancellationToken cancellationToken);
    }
}
