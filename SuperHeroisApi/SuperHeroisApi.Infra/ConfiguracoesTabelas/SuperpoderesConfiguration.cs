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
    public class SuperpoderesConfiguration : IEntityTypeConfiguration<Superpoderes>
    {
        public void Configure(EntityTypeBuilder<Superpoderes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Superpoder).IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Descricao).IsRequired()
                .HasMaxLength(250);
        }
    }
}
