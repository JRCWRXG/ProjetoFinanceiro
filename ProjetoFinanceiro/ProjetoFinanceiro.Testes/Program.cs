using Microsoft.Extensions.DependencyInjection;
using ProjetoFinanceiro.Testes.Extensions;
using ProjetoFinanceiro.Testes.Principal;

namespace ProjetoFinanceiro.Testes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceCollection = ConfigureServices();
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                var eventService = serviceProvider.GetRequiredService<AppTestePrincipal>();
                eventService.Execute();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static IServiceCollection ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDependencies();
            return serviceCollection;
        }
    }
}