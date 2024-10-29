using ExamenBackend.API.Extensions;
using ExamenBackend.API.Middlewares;
using ExamenBackend.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();
