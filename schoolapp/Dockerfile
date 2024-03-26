#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["schoolapp.webapi/schoolapp.webapi.csproj", "schoolapp.webapi/"]
COPY ["schoolapp.domain/schoolapp.domain.csproj", "schoolapp.domain/"]
COPY ["schoolapp.infrastructure/schoolapp.infrastructure.csproj", "schoolapp.infrastructure/"]
COPY ["schoolapp.application/schoolapp.application.csproj", "schoolapp.application/"]
RUN dotnet restore "./schoolapp.webapi/./schoolapp.webapi.csproj"
COPY . .
WORKDIR "/src/schoolapp.webapi"
RUN dotnet build "./schoolapp.webapi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./schoolapp.webapi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "schoolapp.webapi.dll"]