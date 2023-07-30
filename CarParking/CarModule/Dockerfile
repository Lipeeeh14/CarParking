# 1 - Etapa de construção da aplicação
# FROM -- indica a imagem a ser utilizada
# WORKDIR -- diretório que será armazenado
# COPY -- copia o arquivo para o diretório informado
# RUN -- executa o comando indicado
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# 2 - Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "CarModule.dll" ]