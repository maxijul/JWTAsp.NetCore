using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoToken.Models;
using ProyectoToken.Services;
using System.Text;

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

// Inyectamos la dependencia de los servicios
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

// Configuracion del JWT
var key = builder.Configuration.GetValue<string>("JwtSettings:key");
var keyByte = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(config =>
{
  config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(config =>
{
  config.RequireHttpsMetadata = false;
  config.SaveToken = true;
  config.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(keyByte),
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero
  };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Usamos la configuracion que declaramos para el JWT
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
