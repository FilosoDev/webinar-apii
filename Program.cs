using Oficina.WebApi.Contexts;
using Oficina.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<OficinaContext, OficinaContext>();
builder.Services.AddControllers();
builder.Services.AddTransient<CarroRepository, CarroRepository>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
