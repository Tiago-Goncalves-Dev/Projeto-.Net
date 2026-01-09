# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copia csproj e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia tudo e compila
COPY . ./
RUN dotnet publish -c Release -o out /p:TargetFramework=net10.0

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

# Expondo porta padrão Kestrel
EXPOSE 80

# Rodar aplicação usando DLL gerada
ENTRYPOINT ["dotnet", "Projeto_Net.dll"]
