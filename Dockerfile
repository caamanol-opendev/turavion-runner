# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build
WORKDIR /src

# Copiar los archivos de proyecto
COPY src/Application/Application.csproj src/Application/
COPY src/Domain/*.csproj src/Domain/
COPY src/Infrastructure/*.csproj src/Infrastructure/
COPY src/WorkerService/*.csproj src/WorkerService/

# Restaurar las dependencias
RUN dotnet restore src/WorkerService/WorkerService.csproj --ignore-failed-sources

# Copiar el resto de los archivos de código
COPY . .

# Construir y publicar la aplicación
WORKDIR /src/src/WorkerService
RUN dotnet publish -c Release -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "WorkerService.dll"]