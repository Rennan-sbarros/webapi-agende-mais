# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar o arquivo .csproj para o container
COPY webapi-agende-mais.csproj ./

# Restaurar depend�ncias
RUN dotnet restore webapi-agende-mais.csproj

# Copiar o restante do c�digo para o container
COPY ./src ./src

# Compilar o projeto
RUN dotnet publish webapi-agende-mais.csproj -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Passar vari�veis de ambiente para o container
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_USE_POLLING_FILE_WATCHER=true

# Copiar os arquivos publicados
COPY --from=build /out .

# Expor a porta da aplica��o
EXPOSE 80

# Comando para iniciar a aplica��o
ENTRYPOINT ["dotnet", "webapi-agende-mais.dll"]