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
    public class HeroisConfiguration : IEntityTypeConfiguration<Herois>
    {
        public void Configure(EntityTypeBuilder<Herois> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired()
                .HasMaxLength(120);

            builder.Property(x => x.NomeHeroi).IsRequired()
                .HasMaxLength(120);
            builder.HasIndex(x => x.NomeHeroi).IsUnique();

            builder.Property(x => x.DataNascimento).IsRequired();

            builder.Property(x => x.Altura).IsRequired()
                .HasColumnType("float");

            builder.Property(x => x.Peso).IsRequired()
                .HasColumnType("float");
        }
    }
}
