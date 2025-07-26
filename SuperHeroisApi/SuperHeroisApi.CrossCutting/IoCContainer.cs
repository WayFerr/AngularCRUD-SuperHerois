using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHeroisApi.Application.Interfaces;
using SuperHeroisApi.Application.Services;
using SuperHeroisApi.Domain.Interfaces;
using SuperHeroisApi.Infra;
using SuperHeroisApi.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroisApi.CrossCutting
{
    public static class IoCContainer
    {
        public static IServiceCollection AdicionarServicos(this IServiceCollection services)
        {
            services.AddScoped<IHeroiService, HeroiService>();

            return services;
        }

        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IHeroiRepository, HeroiRepository>();

            return services;
        }

        public static IServiceCollection AdicionarBancoDeDados(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SuperHeroisApiContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
