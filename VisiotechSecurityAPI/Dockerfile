# Usa una imagen base de .NET para construir y ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Usa una imagen de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia los archivos del proyecto y restaura las dependencias
COPY ["VisiotechSecurityAPI/VisiotechSecurityAPI.csproj", "VisiotechSecurityAPI/"]
RUN dotnet restore "./VisiotechSecurityAPI/VisiotechSecurityAPI.csproj"
COPY . .
WORKDIR "/src/VisiotechSecurityAPI"
RUN dotnet build "./VisiotechSecurityAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Publica la aplicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VisiotechSecurityAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Usa la imagen base para ejecutar la aplicación publicada
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VisiotechSecurityAPI.dll"]