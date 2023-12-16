using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinanceiro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            IConfiguration configuration = GetConfiguration();
            services.AddSingleton<IConfiguration>(configuration);
            RegisterDependencies(services);
            return services;    
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<AppTestePrincipal>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<RepositorioTeste>();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            return configuration;
        }
    }
}
