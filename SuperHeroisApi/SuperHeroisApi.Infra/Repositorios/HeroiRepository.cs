using Microsoft.EntityFrameworkCore;
using SuperHeroisApi.Domain.Entidades;
using SuperHeroisApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Infra.Repositorios
{
    public class HeroiRepository : IHeroiRepository
    {
        private readonly SuperHeroisApiContext _context;

        public HeroiRepository(SuperHeroisApiContext context)
        {
            _context = context;
        }

        public async Task<Herois> ObterPorId(int id, CancellationToken cancellationToken)
        {
            return await _context.Herois.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Herois>> ObterTodos(CancellationToken cancellationToken)
        {
            var herois = await _context.Herois.AsNoTracking().Include(hs => hs.HeroisSuperpoderes)
                .ThenInclude(s => s.Superpoder).ToListAsync(cancellationToken);

            return herois;
        }
    }
}
