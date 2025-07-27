using SuperHeroisApi.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Application.DTOs.Response
{
    public class SuperpoderResponse
    {
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string Descricao { get; set; }
    }

    public static class SuperpoderResponseExtension
    {
        public static List<SuperpoderResponse> ToResponseModel(this List<Superpoderes> herois)
        {
            return herois.Select(sp => new SuperpoderResponse
            {
                Id = sp.Id,
                Superpoder = sp.Superpoder,
                Descricao = sp.Descricao
            }).ToList();
        }
    }
}
