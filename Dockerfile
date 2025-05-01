# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivos do projeto
COPY ./src /app

# Restaurar depend�ncias
RUN dotnet restore webapi-agende-mais.csproj

# Compilar o projeto
RUN dotnet publish webapi-agende-mais.csproj -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /out .

# Expor a porta da aplica��o
EXPOSE 80

# Comando para iniciar a aplica��o
ENTRYPOINT ["dotnet", "webapi-agende-mais.dll"]
