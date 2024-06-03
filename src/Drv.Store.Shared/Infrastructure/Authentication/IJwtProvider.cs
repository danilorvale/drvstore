namespace Drv.Store.Shared.Infrastructure.Authentication;

public interface IJwtProvider
{
    string Generate(string user);
}