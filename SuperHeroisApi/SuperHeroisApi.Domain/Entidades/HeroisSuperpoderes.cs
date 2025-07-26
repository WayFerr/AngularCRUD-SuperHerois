using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Domain.Entidades
{
    public class HeroisSuperpoderes
    {
        public int HeroiId { get; set; }
        public int SuperpoderId { get; set; }
        public Herois Heroi { get; set; }
        public Superpoderes Superpoder { get; set; }
    }
}
