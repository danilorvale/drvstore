FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Drv.Store.Order.Api/Drv.Store.Order.Api.csproj", "src/Drv.Store.Order.Api/"]
RUN dotnet restore "src/Drv.Store.Order.Api/Drv.Store.Order.Api.csproj"
COPY . .
WORKDIR "/src/src/Drv.Store.Order.Api"
RUN dotnet build "Drv.Store.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Drv.Store.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Drv.Store.Order.Api.dll"]
