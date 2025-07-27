using SuperHeroisApi.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Application.DTOs.Response
{
    public class HeroiResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public List<HeroiSuperpoderViewModel> Superpoderes { get; set; }
    }

    public class HeroiSuperpoderViewModel
    {
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string Descricao { get; set; }
    }

    public static class HeroiResponseExtension
    {
        public static HeroiResponse ToResponseModel(this Herois heroi)
        {
            return new HeroiResponse
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso
            };
        }

        public static List<HeroiResponse> ToResponseModel(this List<Herois> herois)
        {
            return herois.Select(heroi => new HeroiResponse
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.HeroisSuperpoderes.Select(x =>  new HeroiSuperpoderViewModel
                {
                    Id = x.Superpoder.Id,
                    Superpoder = x.Superpoder.Superpoder,
                    Descricao = x.Superpoder.Descricao
                }).ToList()
            }).ToList();
        }
    }
}
