using System.Reflection;
using Bokunda.Preslovitelj.Cqrs.Commands;
using Bokunda.Preslovitelj.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register Swagger Services.
builder.Services.AddSwaggerDocument(settings =>
{
    settings.Title = "Bokunda.Preslovitelj.Api";
    settings.Version = "v1";
});

builder.Services.AddDbContext<PresloviteljContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TranslateTextCommand).GetTypeInfo().Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
