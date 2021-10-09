#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SimpleApp.Api/SimpleApp.Api.csproj", "SimpleApp.Api/"]
COPY ["SimpleApp.Persistence/SimpleApp.Persistence.csproj", "SimpleApp.Persistence/"]
COPY ["SimpleApp.Domain/SimpleApp.Domain.csproj", "SimpleApp.Domain/"]
RUN dotnet restore "SimpleApp.Api/SimpleApp.Api.csproj"
COPY . .
WORKDIR "/src/SimpleApp.Api"
RUN dotnet build "SimpleApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleApp.Api.dll"]