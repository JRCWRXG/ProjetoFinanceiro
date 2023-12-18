using Microsoft.Extensions.Options;
using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Service;

namespace ProjetoFinanceiro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<ClienteService>();

           

            builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection(nameof(ApiConfig))); 
            builder.Services.AddSingleton<IApiConfig>(x => 
                x.GetRequiredService<IOptions<ApiConfig>>().Value);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}