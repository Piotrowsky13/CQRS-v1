FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5181

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["./Mariusz.Piotrowski.sln", "."]
COPY Mariusz.Piotrowski/ Mariusz.Piotrowski/
COPY Mariusz.Piotrowski.Domain/ Mariusz.Piotrowski.Domain/
COPY Mariusz.Piotrowski.Application/ Mariusz.Piotrowski.Application/
COPY Mariusz.Piotrowski.Infrastructure/ Mariusz.Piotrowski.Infrastructure/

WORKDIR /src/Mariusz.Piotrowski
RUN dotnet restore
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5181
ENTRYPOINT ["dotnet", "Mariusz.Piotrowski.Api.dll"]

