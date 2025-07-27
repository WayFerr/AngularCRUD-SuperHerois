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

        public async Task<Herois> Cadastro(Herois heroi, CancellationToken cancellationToken)
        {
            await _context.Herois.AddAsync(heroi, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return heroi;
        }

        public async Task<Herois> ObterPorNomeDeHeroi(string nomeHeroi, CancellationToken cancellationToken)
        {
            return await _context.Herois.AsNoTracking().FirstOrDefaultAsync(x => x.NomeHeroi == nomeHeroi, cancellationToken);
        }

        public async Task Update(Herois heroi, CancellationToken cancellationToken)
        {
            _context.Herois.Update(heroi);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Herois heroi, CancellationToken cancellationToken)
        {
            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Superpoderes>> ObterTodosSuperpoderes(CancellationToken cancellationToken)
        {
            var superpoderes = await _context.Superpoderes.AsNoTracking().ToListAsync();

            return superpoderes;
        }

        public async Task<Herois?> ObterPorIdComSuperpoderes(int id, CancellationToken cancellationToken)
        {
            return await _context.Herois.Include(h => h.HeroisSuperpoderes).FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
        }
    }
}
