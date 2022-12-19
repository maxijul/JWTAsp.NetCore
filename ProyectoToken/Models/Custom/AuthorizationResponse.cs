namespace ProyectoToken.Models.Custom
{
  public class AuthorizationResponse
  {
    public string? Token { get; set; }
    public bool Resultado { get; set; }
    public string? Mensaje { get; set; }
  }
}
