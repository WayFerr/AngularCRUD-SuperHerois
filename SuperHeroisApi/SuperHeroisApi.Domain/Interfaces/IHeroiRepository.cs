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
    }
}
