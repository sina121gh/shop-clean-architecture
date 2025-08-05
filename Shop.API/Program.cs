using DotNetEnv;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shop.Persistence;
using Shop.Persistence.Context;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.ConfigurePersistenceServices(Env.GetString("SQL_SERVER_CONNECTION_STRING"));
builder.Services.AddMapster();

var app = builder.Build();

#region Migrating Database

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ShopDbContext>();
    //await context.Database.EnsureCreatedAsync();
    await context.Database.MigrateAsync();
}

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
