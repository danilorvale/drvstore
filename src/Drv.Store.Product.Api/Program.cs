using System.Text;
using System.Text.Json.Serialization;
using Drv.Store.Product.Api.Endpoints;
using Drv.Store.Product.Api.Extensions;
using Drv.Store.Product.Api.Middleware;
using Drv.Store.Product.Api.OptionsSetup;
using Drv.Store.Product.Application;
using Drv.Store.Product.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenJwt("v1", new OpenApiInfo { Title = "Drv.Store.Product.Api", Version = "v1" });
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapProductEndpoints();
app.MapUserEndpoints();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();