using Microsoft.EntityFrameworkCore;
using SuperHeroisApi.Domain.Entidades;
using SuperHeroisApi.Infra.ConfiguracoesTabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.Infra
{
    public class SuperHeroisApiContext : DbContext
    {
        public SuperHeroisApiContext(DbContextOptions<SuperHeroisApiContext> options) : base(options) { }

        public DbSet<Herois> Herois { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HeroisConfiguration());
            modelBuilder.ApplyConfiguration(new SuperpoderesConfiguration());
            modelBuilder.ApplyConfiguration(new HeroisSuperpoderesConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
