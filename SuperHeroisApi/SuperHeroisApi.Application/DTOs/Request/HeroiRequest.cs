using SuperHeroisApi.Application.DTOs.Response;
using SuperHeroisApi.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Application.DTOs.Request
{
    public class HeroiRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 120 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome do herói é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Nome do herói deve ter no máximo 120 caracteres")]
        public string NomeHeroi { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória", AllowEmptyStrings = false)]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Altura é obrigatória", AllowEmptyStrings = false)]
        public double? Altura { get; set; }

        [Required(ErrorMessage = "Peso é obrigatório", AllowEmptyStrings = false)]
        public double? Peso { get; set; }
        public List<int>? SuperpoderIds { get; set; }
    }

    public static class HeroiRequestExtension
    {
        public static Herois ToEntity(this HeroiRequest heroi, int id = 0)
        {
            return new Herois
            {
                Id = id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento.Value,
                Altura = heroi.Altura.Value,
                Peso = heroi.Peso.Value
            };
        }
    }
}
