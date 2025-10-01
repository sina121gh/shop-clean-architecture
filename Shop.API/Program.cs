using DotNetEnv;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.API.Configs;
using Shop.API.Endpoints;
using Shop.API.Middlewares;
using Shop.Application;
using Shop.Application.Configuration;
using Shop.Infrastructure;
using Shop.Persistence;
using Shop.Persistence.Context;
using System.Text;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
SwaggerConfig.AddSwagger(builder.Services);

#region Jwt Settings

var jwtKey = Env.GetString("JWT_KEY");
var jwtIssuer = Env.GetString("JWT_ISSUER");
var jwtAudience = Env.GetString("JWT_AUDIENCE");
var jwtExpireMinutes = Env.GetInt("JWT_EXPIRE_MINUTES");

builder.Services.Configure<JwtSettings>(options =>
{
    options.Key = jwtKey;
    options.Issuer = jwtIssuer;
    options.Audience = jwtAudience;
    options.ExpireMinutes = jwtExpireMinutes;
});

#endregion

builder.Services.AddHttpContextAccessor();
builder.Services.ConfigurePersistenceServices(Env.GetString("SQL_SERVER_CONNECTION_STRING"));
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(Env.GetString("REDIS_CONNECTION_STRING"));
builder.Services.AddMapster();

#region Authentication Config

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

#endregion

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
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapCategoryEndpoints();

app.Run();
