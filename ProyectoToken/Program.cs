using Microsoft.EntityFrameworkCore;
using ProyectoToken.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Añadimos la cadena de conexion configurando el dbContext
builder.Services.AddDbContext<DbpruebaContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
