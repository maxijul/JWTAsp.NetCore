using ProyectoToken.Models.Custom;

namespace ProyectoToken.Services
{
  public interface IAuthorizationService
  {
    Task<AuthorizationResponse> DevolverToken(AuthorizationRequest autorizacion);
    Task<AuthorizationResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int id);
  }
}
