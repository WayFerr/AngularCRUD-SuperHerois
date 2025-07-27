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

            builder.HasData(
                new Superpoderes { Id = 1, Superpoder = "Força Sobre-Humana", Descricao = "Capacidade de exercer força física muito além dos limites humanos." },
                new Superpoderes { Id = 2, Superpoder = "Voo", Descricao = "Habilidade de voar sem ajuda de equipamentos." },
                new Superpoderes { Id = 3, Superpoder = "Telepatia", Descricao = "Capacidade de ler ou comunicar-se com a mente de outras pessoas." },
                new Superpoderes { Id = 4, Superpoder = "Invisibilidade", Descricao = "Capacidade de tornar o corpo invisível à visão humana." },
                new Superpoderes { Id = 5, Superpoder = "Manipulação do Tempo", Descricao = "Habilidade de desacelerar, acelerar ou parar o tempo temporariamente." }
    );
        }
    }
}
