FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src


COPY Shop.API/Shop.API.csproj Shop.API/
COPY Shop.Application/Shop.Application.csproj Shop.Application/
COPY Shop.Domain/Shop.Domain.csproj Shop.Domain/
COPY Shop.Infrastructure/Shop.Infrastructure.csproj Shop.Infrastructure/
COPY Shop.Persistence/Shop.Persistence.csproj Shop.Persistence/
COPY Shop.sln ./
RUN dotnet restore

COPY . .

WORKDIR /src/Shop.API
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app .

RUN apt-get update && apt-get install -y libkrb5-3 libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*

ENTRYPOINT ["dotnet", "Shop.API.dll"]
