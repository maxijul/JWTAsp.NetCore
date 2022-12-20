using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoToken.Models.Custom;
using ProyectoToken.Services;
using System.IdentityModel.Tokens.Jwt;

namespace ProyectoToken.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsuarioController : ControllerBase
  {
    private readonly IAuthorizationService _authorizationService;

    public UsuarioController(IAuthorizationService authorizationService)
    {
      _authorizationService = authorizationService;
    }


    [HttpPost]
    [Route("Autenticar")]
    // Aqui autenticamos si el parametro que recibimos del body son credenciales correctas asi devolvemos el token
    public async Task<IActionResult> Autenticar([FromBody] AuthorizationRequest autorizacion)
    {
      var resultadoAutorizacion = await _authorizationService.DevolverToken(autorizacion);

      if (resultadoAutorizacion == null)
        return Unauthorized();

      return Ok(resultadoAutorizacion);
      
    }

    [HttpPost]
    [Route("ObtenerRefreshToken")]
    public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenExpiradoSupuestamente = tokenHandler.ReadJwtToken(request.TokenExpirado);

      if (tokenExpiradoSupuestamente.ValidTo > DateTime.UtcNow)
        return BadRequest(new AuthorizationResponse { Resultado = false, Mensaje = "Token no ha expirado" });

      string idUsuario = tokenExpiradoSupuestamente.Claims.First(x =>
        x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();
        
      var autorizacionResponse = await _authorizationService.DevolverRefreshToken(request, int.Parse(idUsuario));

      if (autorizacionResponse.Resultado)
        return Ok(autorizacionResponse);
      else
        return BadRequest(autorizacionResponse);
    }

  }
}
