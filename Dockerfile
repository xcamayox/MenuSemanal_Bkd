# --- ETAPA 1: Build (Compilación y Publicación) ---
# Usamos el SDK oficial de .NET para compilar la aplicación (asegúrate de usar la versión correcta, ej. 8.0 o 9.0)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos el archivo de solución (.sln) principal
COPY ["MenuSemanal.sln", "./"]

# 2. Copiamos cada archivo .csproj en su respectiva ruta relativa para restaurar dependencias
COPY ["MenuSemanal.Domain/MenuSemanal.Domain.csproj", "MenuSemanal.Domain/"]
COPY ["MenuSemanal.Application/MenuSemanal.Application.csproj", "MenuSemanal.Application/"]
COPY ["MenuSemanal.Infrastructure/MenuSemanal.Infrastructure.csproj", "MenuSemanal.Infrastructure/"]
COPY ["MenuSemanal.WebAPI/MenuSemanal.WebAPI.csproj", "MenuSemanal.WebAPI/"]

# Restauramos las dependencias de todos los proyectos a través del WebAPI
RUN dotnet restore "MenuSemanal.WebAPI/MenuSemanal.WebAPI.csproj"

# 3. Copiamos todo el código fuente restante de la solución
COPY . .

# Nos movemos a la carpeta del proyecto de la API y publicamos en modo Release
WORKDIR "/src/MenuSemanal.WebAPI"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# --- ETAPA 2: Runtime (Entorno de Ejecución Ligero) ---
# Usamos la imagen de ASP.NET Core (solo runtime, más ligera y segura para producción)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Render expone el puerto mediante la variable PORT, pero por defecto abrimos el 8080
EXPOSE 8080

# Copiamos los archivos publicados desde la etapa de build
COPY --from=build /app/publish .

# Comando para arrancar la API cuando el contenedor se inicie
ENTRYPOINT ["dotnet", "MenuSemanal.WebAPI.dll"]