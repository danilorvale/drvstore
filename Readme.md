# Drv Store

Drv Store é um projeto de e-commerce que inclui módulos de produto e pedido. O projeto é construído usando C# e .NET 8.0.

## Pré-requisitos

- .NET 8.0 SDK
- Docker (para o banco de dados e o broker de mensagens)

## Configuração

1. Clone o repositório para a sua máquina local usando `git clone`.

2. Navegue até a pasta raiz do projeto.

3. Execute o comando `docker-compose up` para iniciar o banco de dados e o broker de mensagens.

## Execução

1. Navegue até a pasta `src/Drv.Store.Product.Api` e execute o comando `dotnet run` para iniciar o serviço de produto.

2. Navegue até a pasta `src/Drv.Store.Order.Api` e execute o comando `dotnet run` para iniciar o serviço de pedido.

## Testes

Para executar os testes, navegue até a pasta `src/Drv.Store.Product.Tests` ou `src/Drv.Store.Order.Tests` e execute o comando `dotnet test`.

## Contribuição

Por favor, leia [CONTRIBUTING.md](CONTRIBUTING.md) para detalhes sobre o nosso código de conduta e o processo para enviar pedidos pull para nós.

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE.md](LICENSE.md) para detalhes.