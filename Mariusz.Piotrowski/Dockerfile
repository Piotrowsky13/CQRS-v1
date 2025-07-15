# Etap build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kopiujemy wszystkie potrzebne foldery
COPY ./Mariusz.Piotrowski ./Mariusz.Piotrowski
COPY ./Mariusz.Piotrowski.Application ./Mariusz.Piotrowski.Application
COPY ./Mariusz.Piotrowski.Infrastructure ./Mariusz.Piotrowski.Infrastructure
COPY ./Mariusz.Piotrowski.Domain ./Mariusz.Piotrowski.Domain

WORKDIR /app/Mariusz.Piotrowski
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etap uruchomienia
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/Mariusz.Piotrowski/out .

ENTRYPOINT ["dotnet", "Mariusz.Piotrowski.Api.dll"]