# --- ETAPA 1: Build (Compilación y Publicación) ---
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos el archivo de solución principal
COPY ["MenuSemanal.sln", "./"]

# 2. Copiamos cada proyecto individualmente usando los nombres reales de tus carpetas
COPY ["MenuSemanal.Application/MenuSemanal.Application.csproj", "MenuSemanal.Application/"]
COPY ["MenuSemanal.Domain/MenuSemanal.Domain.csproj", "MenuSemanal.Domain/"]
COPY ["MenuSemanal.Infrastructure/MenuSemanal.Infrastructure.csproj", "MenuSemanal.Infrastructure/"]
COPY ["MenuSemanal.Presentation/MenuSemanal.Presentation.csproj", "MenuSemanal.Presentation/"]

# Restauramos las dependencias apuntando a Presentation
RUN dotnet restore "MenuSemanal.Presentation/MenuSemanal.Presentation.csproj"

# 3. Copiamos todo el código fuente restante
COPY . .

# Nos movemos a la carpeta Presentation y publicamos
WORKDIR "/src/MenuSemanal.Presentation"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# --- ETAPA 2: Runtime (Entorno de Ejecución) ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 8080

# Copiamos los archivos compilados
COPY --from=build /app/publish .

# Ejecutamos la DLL correspondiente a tu proyecto Presentation
ENTRYPOINT ["dotnet", "MenuSemanal.Presentation.dll"]