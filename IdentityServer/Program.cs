using IdentityServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityServer()
       .AddInMemoryClients(Config.Clients)
       //.AddInMemoryApiResources(Config.ApiResources)
       .AddInMemoryApiScopes(Config.ApiScopes)
       .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseRouting(); 
app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
