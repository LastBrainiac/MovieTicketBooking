#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MTBS.BookingAPI/MTBS.BookingAPI.csproj", "MTBS.BookingAPI/"]
COPY ["MTBS.EventBus/MTBS.EventBus.csproj", "MTBS.EventBus/"]
RUN dotnet restore "MTBS.BookingAPI/MTBS.BookingAPI.csproj"
COPY . .
WORKDIR "/src/MTBS.BookingAPI"
RUN dotnet build "MTBS.BookingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTBS.BookingAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTBS.BookingAPI.dll"]