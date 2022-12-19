using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProyectoToken.Models;
using ProyectoToken.Models.Custom;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ProyectoToken.Services
{
  public class AuthorizationService : IAuthorizationService
  {

    private readonly DbpruebaContext _context;
    private readonly IConfiguration _configuration;

    public AuthorizationService(DbpruebaContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }

    private string GenerarToken(string id)
    {
      // Obtenemos la key del token y lo pasamos a un array
      var key = _configuration.GetValue<string>("JwtSettings:key");
      var keyByte = Encoding.ASCII.GetBytes(key);

      // Tomamos el identificador de la sesion que sera un id
      var claims = new ClaimsIdentity();
      claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));

      //Credenciales para el token se le pasa la key del array y el algoritmo de encriptado
      var credencialesToken = new SigningCredentials(
        new SymmetricSecurityKey(keyByte),
        SecurityAlgorithms.HmacSha256Signature
        );

      // Contenido del token, su identificador, cuando expira y las credenciales
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = claims,
        Expires = DateTime.UtcNow.AddMinutes(1),
        SigningCredentials = credencialesToken
      };
      
      // Creamos el token
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
      
      // Devolvemos el token ya creado
      string tokenCreado = tokenHandler.WriteToken(tokenConfig);
      return tokenCreado;

    }



    public Task<AuthorizationResponse> DevolverToken(AuthorizationRequest autorizacion)
    {
      
    }
  }
}
