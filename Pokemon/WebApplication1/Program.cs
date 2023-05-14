using Infra.Data;
using Infra.Middleware;
using Service.API.ApiConfig;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);

var app = builder.Build();
Configure(app);

#region | Configura��es das Depend�ncias |
void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddCorsConfiguration();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<DbPokemon>();
    builder.Services.AddTransient<GlobalException>();
    builder.Services.AddGeneralApiServices();
    builder.Services.AddGeneralApiRepositories();
}
#endregion

#region | Configura��es da Aplica��es |
void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCustomExceptionMiddleware();
    app.UseHttpsRedirection();
    app.UseCors("Total");
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
#endregion