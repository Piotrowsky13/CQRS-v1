using Mariusz.Piotrowski.Api.Middleware;
using Mariusz.Piotrowski.Application;
using Mariusz.Piotrowski.Infrastructure;
using Mariusz.Piotrowski.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MariuszPiotrowski Pakiet A",
        Version = "v1",
        Description = "API for managing articles using CQRS with MediatR",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Mariusz Piotrowski",
            Email = "piotrowsky13@gmail.com"
        }
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
