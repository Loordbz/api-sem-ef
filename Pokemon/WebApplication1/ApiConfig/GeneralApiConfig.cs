using Domain.Interface.Respositorys;
using Domain.Interface.Services;
using Infra.Middleware;
using Infra.Repository;
using Service.Service;

namespace Service.API.ApiConfig;

public static class GeneralApiConfig
{
    public static IServiceCollection AddGeneralApiServices(this IServiceCollection services)
    {
        services.AddScoped<ITipoService, TipoService>();
        services.AddScoped<IPokemonService, PokemonService>();
        return services;
    }

    public static IServiceCollection AddGeneralApiRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITipoRepository, TipoRepository>();
        services.AddScoped<IPokemonRepository, PokemonRepository>();

        return services;
    }

    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
        services.AddCors(opt =>
        {
            opt.AddPolicy("Total", builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });

    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app) =>
       app.UseMiddleware<GlobalException>();
}