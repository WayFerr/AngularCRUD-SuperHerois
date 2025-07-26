using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Domain.Entidades
{
    public class Superpoderes
    {
        public Superpoderes()
        {
            HeroisSuperpoderes = new Collection<HeroisSuperpoderes>();
        }
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string Descricao { get; set; }
        public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
    }
}
