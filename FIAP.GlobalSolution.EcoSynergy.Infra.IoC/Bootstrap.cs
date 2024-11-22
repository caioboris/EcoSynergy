using FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;
using FIAP.GlobalSolution.EcoSynergy.Application.Services;
using FIAP.GlobalSolution.EcoSynergy.Domain.Interfaces;
using FIAP.GlobalSolution.EcoSynergy.Infra.Data;
using FIAP.GlobalSolution.EcoSynergy.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.GlobalSolution.EcoSynergy.Infra.IoC;

public static class Bootstrap
{
    public static void Start(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(x =>
        {
            x.UseOracle(configuration["ConnectionStrings:Oracle"]);
        });

        services.AddRepositories();
        services.AddServices();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IProducaoEnergiaService, ProducaoEnergiaService>();
        services.AddTransient<IPainelService, PainelService>();
        services.AddTransient<IPredicaoService, PredicaoService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IProducaoEnergiaRepository, ProducaoEnergiaRepository>();
        services.AddTransient<IPainelRepository, PainelRepository>();
    }
}
