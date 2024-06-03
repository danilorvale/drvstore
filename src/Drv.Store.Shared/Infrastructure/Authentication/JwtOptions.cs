namespace Drv.Store.Shared.Infrastructure.Authentication;

public class JwtOptions
{
    public string Audience { get; init; }

    public string SecretKey { get; init; }
    public string Issuer { get; set; }
}