using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoToken.Models.Custom;
using ProyectoToken.Services;


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
    // Aqui autenticamos si el parametro que recibimos del body es un token correcto y devolvemos segun lo que corresponda
    public async Task<IActionResult> Autenticar([FromBody] AuthorizationRequest autorizacion)
    {
      var resultadoAutorizacion = await _authorizationService.DevolverToken(autorizacion);

      if (resultadoAutorizacion == null)
        return Unauthorized();

      return Ok(resultadoAutorizacion);
      
    }

  }
}
