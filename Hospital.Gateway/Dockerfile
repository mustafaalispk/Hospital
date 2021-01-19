#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Hospital.Gateway/Hospital.Gateway.csproj", "Hospital.Gateway/"]
RUN dotnet restore "Hospital.Gateway/Hospital.Gateway.csproj"
COPY . .
WORKDIR "/src/Hospital.Gateway"
RUN dotnet build "Hospital.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hospital.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hospital.Gateway.dll"]
