@echo off
setlocal enabledelayedexpansion

set "IMAGE_NAME=turavion-back-runner"
set "CONTAINER_NAME=turavion-runner"

echo Deteniendo contenedores existentes...
for /f "tokens=*" %%i in ('docker ps -q --filter ancestor^=%IMAGE_NAME%') do (
    docker stop %%i
)

echo Eliminando contenedores existentes...
for /f "tokens=*" %%i in ('docker ps -a -q --filter ancestor^=%IMAGE_NAME%') do (
    docker rm %%i
)

echo Eliminando imagen existente...
docker rmi %IMAGE_NAME% -f

echo Construyendo nueva imagen...
docker build -t %IMAGE_NAME% .
if %errorlevel% neq 0 (
    echo Error al construir la imagen
    exit /b %errorlevel%
)

echo Iniciando nuevo contenedor...
docker run -d --name %CONTAINER_NAME% %IMAGE_NAME%
if %errorlevel% neq 0 (
    echo Error al iniciar el contenedor
    exit /b %errorlevel%
)

echo Mostrando contenedores en ejecucion...
docker ps

echo Proceso completado!
endlocal
