#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FilmsApp.WebApi/FilmsApp.WebApi.csproj", "FilmsApp.WebApi/"]
COPY ["FilmsApp.Data/FilmsApp.Data.csproj", "FilmsApp.Data/"]
RUN dotnet restore "FilmsApp.WebApi/FilmsApp.WebApi.csproj"
COPY . .
WORKDIR "/src/FilmsApp.WebApi"
RUN dotnet build "FilmsApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FilmsApp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FilmsApp.WebApi.dll"]