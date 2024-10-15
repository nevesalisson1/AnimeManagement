using Application.Animes.AppServices;
using Application.Localidade.AutoMapper;
using Domain.Animes.Repository;
using Domain.Animes.Services.Implementations;
using Domain.Animes.Services.Interfaces;
using Infrastructure.Domain.Animes.Context.Implementations;
using Infrastructure.Domain.Animes.Context.Interfaces;
using Infrastructure.Domain.Animes.Mapping.Implementations;
using Infrastructure.Domain.Animes.Mapping.Interfaces;
using Infrastructure.Domain.Animes.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ResolverFactoryAnimes
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        RegisterServiceLayer(services);
        RegisterApplicationLayer(services);
        RegisterInfrastructureLayer(services, configuration);
    }

    private static void RegisterServiceLayer(IServiceCollection services)
    {
        services.AddScoped<IAnimeService, AnimeService>();
    }

    private static void RegisterApplicationLayer(IServiceCollection services)
    {
        services.AddScoped<IAnimeAppService, AnimeAppService>();
    }

    private static void RegisterInfrastructureLayer(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAnimeRepository, AnimeRepository>();
        services.AddScoped<IAnimeMapping, AnimeMapping>();

        services.AddDbContext<AnimesPostgresContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var animeMapping = serviceProvider.GetRequiredService<IAnimeMapping>();

            var connectionStrings = configuration.GetSection("ConnectionStrings");

            options.UseNpgsql(connectionStrings["PostgresConnection"]);
        }, ServiceLifetime.Scoped);

        services.AddScoped<IAnimesContext>(provider => provider.GetService<AnimesPostgresContext>());
    }
}