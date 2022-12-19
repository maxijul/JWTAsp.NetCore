using ProyectoToken.Models.Custom;

namespace ProyectoToken.Services
{
  public interface IAuthorizationService
  {
    Task<AuthorizationResponse> DevolverToken(AuthorizationRequest autorizacion);
  }
}
