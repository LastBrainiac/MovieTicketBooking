#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MTBS.MovieCatalogAPI/MTBS.MovieCatalogAPI.csproj", "MTBS.MovieCatalogAPI/"]
RUN dotnet restore "MTBS.MovieCatalogAPI/MTBS.MovieCatalogAPI.csproj"
COPY . .
WORKDIR "/src/MTBS.MovieCatalogAPI"
RUN dotnet build "MTBS.MovieCatalogAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTBS.MovieCatalogAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTBS.MovieCatalogAPI.dll"]