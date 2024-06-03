using System.Text.Json.Serialization;
using Drv.Store.Order.Api.Endpoints;
using Drv.Store.Order.Api.Extensions;
using Drv.Store.Order.Api.Middleware;
using Drv.Store.Order.Api.OptionsSetup;
using Drv.Store.Order.Infrastructure;
using Drv.Store.Order.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenJwt("v1", new OpenApiInfo { Title = "Drv.Store.Order.Api", Version = "v1" });
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
app.MapUserEndpoints();
app.MapOrderEndpoints();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();