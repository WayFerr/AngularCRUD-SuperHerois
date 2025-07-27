using SuperHeroisApi.Application.DTOs.Request;
using SuperHeroisApi.Application.DTOs.Response;
using SuperHeroisApi.Application.Interfaces;
using SuperHeroisApi.Domain.Entidades;
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

        public async Task<HeroiResponse> Cadastro(HeroiRequest request, CancellationToken cancellationToken)
        {
            var verificaExistencia = await _heroiRepository.ObterPorNomeDeHeroi(request.NomeHeroi, cancellationToken);
            if(verificaExistencia is not null) throw new InvalidOperationException("Já existe um herói com esse nome de herói.");

            var heroi = await _heroiRepository.Cadastro(request.ToEntity(), cancellationToken);

            return heroi.ToResponseModel();
        }

        public async Task<HeroiResponse> Update(int id, HeroiRequest request, CancellationToken cancellationToken)
        {
            var heroi = await _heroiRepository.ObterPorIdComSuperpoderes(id, cancellationToken);
            if (heroi is null) return null;

            heroi.Nome = request.Nome;
            heroi.NomeHeroi = request.NomeHeroi;
            heroi.DataNascimento = request.DataNascimento.Value;
            heroi.Altura = request.Altura.Value;
            heroi.Peso = request.Peso.Value;

            var poderesAtuais = heroi.HeroisSuperpoderes.Select(hs => hs.SuperpoderId).ToList();
            var novosPoderes = request.SuperpoderIds ?? new List<int>();

            var poderesParaAdicionar = novosPoderes.Except(poderesAtuais).ToList();
            foreach (var spId in poderesParaAdicionar)
            {
                heroi.HeroisSuperpoderes.Add(new HeroisSuperpoderes
                {
                    HeroiId = id,
                    SuperpoderId = spId
                });
            }

            var poderesParaRemover = poderesAtuais.Except(novosPoderes).ToList();
            var superpoderesParaRemover = heroi.HeroisSuperpoderes
                .Where(hs => poderesParaRemover.Contains(hs.SuperpoderId))
                .ToList();

            foreach (var sp in superpoderesParaRemover)
            {
                heroi.HeroisSuperpoderes.Remove(sp);
            }

            //heroi = request.ToEntity(id);

            await _heroiRepository.Update(heroi, cancellationToken);

            return heroi.ToResponseModel();
        }

        public async Task<HeroiResponse> Delete(int id, CancellationToken cancellationToken)
        {
            var heroi = await _heroiRepository.ObterPorId(id, cancellationToken);
            if (heroi is null) return null;

            await _heroiRepository.Delete(heroi, cancellationToken);

            return heroi.ToResponseModel();
        }

        public async Task<List<SuperpoderResponse>> ObterTodosSuperpoderes(CancellationToken cancellationToken)
        {
            var superpoderes = await _heroiRepository.ObterTodosSuperpoderes(cancellationToken);

            return superpoderes.ToResponseModel();
        }
    }
}
