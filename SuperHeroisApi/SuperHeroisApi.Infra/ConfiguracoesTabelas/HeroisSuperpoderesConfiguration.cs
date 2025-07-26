using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperHeroisApi.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Infra.ConfiguracoesTabelas
{
    public class HeroisSuperpoderesConfiguration : IEntityTypeConfiguration<HeroisSuperpoderes>
    {
        public void Configure(EntityTypeBuilder<HeroisSuperpoderes> builder)
        {
            builder.HasKey(x => new { x.HeroiId, x.SuperpoderId });

            builder.HasOne(x => x.Heroi).WithMany(h => h.HeroisSuperpoderes)
                .HasForeignKey(x => x.HeroiId);

            builder.HasOne(x => x.Superpoder).WithMany(s => s.HeroisSuperpoderes)
                .HasForeignKey(x => x.SuperpoderId);
        }
    }
}
