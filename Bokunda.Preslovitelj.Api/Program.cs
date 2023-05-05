using System.Reflection;
using Bokunda.Preslovitelj.Cqrs.Commands;
using Bokunda.Preslovitelj.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

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

app.UseCors(myAllowSpecificOrigins);


app.Run();
