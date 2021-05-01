#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["cqrs-demo/cqrs-demo.csproj", "cqrs-demo/"]
RUN dotnet restore "cqrs-demo/cqrs-demo.csproj"
COPY . .
WORKDIR "/src/cqrs-demo"
RUN dotnet build "cqrs-demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cqrs-demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cqrs-demo.dll"]