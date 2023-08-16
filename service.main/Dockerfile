# Use the official ASP.NET runtime image for .NET 7
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 7 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["service.main/service.main.csproj", "service.main/"]
COPY ["service.main.application/service.main.application.csproj", "service.main.application/"]
COPY ["service.main.infrastructure/service.main.infrastructure.csproj", "service.main.infrastructure/"]
COPY ["service.main.domain/service.main.domain.csproj", "service.main.domain/"]
RUN dotnet restore "service.main/service.main.csproj"

# Copy the rest of the application and build
COPY . .
WORKDIR "/src/service.main"
RUN dotnet build "service.main.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "service.main.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service.main.dll"]