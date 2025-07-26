using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Domain.Entidades
{
    public class Herois
    {
        public Herois()
        {
            HeroisSuperpoderes = new Collection<HeroisSuperpoderes>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
    }
}
