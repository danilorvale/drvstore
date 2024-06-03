using Drv.Store.Order.Application.Abstractions;
using Drv.Store.Order.Domain.Constracts;
using Microsoft.Extensions.Configuration;
using Refit;

namespace Drv.Store.Order.Infrastructure.Service;

public class ProductService(IProductApi productApi, IConfiguration configuration) : IProductService
{
    public string Token { get; private set; } = string.Empty;

    public async Task<GeProductResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var header = await BuildHeadersAsync(cancellationToken);
        var response = await productApi.GetProductById(header, id, cancellationToken);

        return response;
    }

    private async Task AuthenticateAsync(CancellationToken cancellationToken, bool tokenExpired = false)
    {
        if (Token != string.Empty || tokenExpired)
            return;

        try
        {
            string? userName = configuration["apiProductUser"];
            string? password = configuration["apiProductPassword"];

            if (userName == string.Empty || password == string.Empty)
                throw new ArgumentException("apiProductUser or apiProductPassword is empty");

            var header = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }, { "charset", "utf8" }
            };

            string token = await productApi.AuthenticateAsync(header, new UserAuthenticateRequest(userName, password), cancellationToken);
            Token = token.Replace("\"","");
        }
        catch (ApiException ex)
        {
            Dictionary<string, string>? errors = await ex.GetContentAsAsync<Dictionary<string, string>>();

            string message = string.Join("; ", errors.Values);

            throw new Exception($"Erro de integração com API de Produto: {message}");
        }
    }

    private async Task<Dictionary<string,string>> BuildHeadersAsync(CancellationToken cancellationToken)
    {
        if (Token == string.Empty)
            await AuthenticateAsync(cancellationToken);

        return new Dictionary<string, string>
        {
            { "Authorization", $"Bearer {Token}"},
            { "Content-Type", "application/json" },
            { "charset", "utf8"}
        };
    }
}