using System.Reflection;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Movies.API.Context;
using Movies.API.Interfaces;
using Movies.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => {
    options.UseInMemoryDatabase("Movies");
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

try
{
    using var scope = app.Services.CreateScope();
    var dataContextService = scope.ServiceProvider.GetRequiredService<DataContext>();
    Seed.SeedData(dataContextService);
}
catch (Exception ex)
{
    using var scope = app.Services.CreateScope();
    var iLoggerService = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    iLoggerService.LogError(ex, "Something occurred wrong  when do migration seed to database");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
