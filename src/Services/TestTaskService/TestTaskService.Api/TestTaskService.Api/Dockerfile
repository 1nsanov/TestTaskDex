# Use the official ASP.NET runtime image for .NET 7
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 7 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["src/Services/TestTaskService/TestTaskService.Api/TestTaskService.Api/TestTaskService.Api.csproj", "src/Services/TestTaskService/TestTaskService.Api/TestTaskService.Api/"]
COPY ["src/Services/TestTaskService/TestTaskService.Application/TestTaskService.Application/TestTaskService.Application.csproj", "src/Services/TestTaskService/TestTaskService.Application/TestTaskService.Application/"]
COPY ["src/Services/TestTaskService/TestTaskService.Infrastructure/TestTaskService.Infrastructure/TestTaskService.Infrastructure.csproj", "src/Services/TestTaskService/TestTaskService.Infrastructure/TestTaskService.Infrastructure/"]
COPY ["src/Services/TestTaskService/TestTaskService.Domain/TestTaskService.Domain/TestTaskService.Domain.csproj", "src/Services/TestTaskService/TestTaskService.Domain/TestTaskService.Domain/"]
RUN dotnet restore "src/Services/TestTaskService/TestTaskService.Api/TestTaskService.Api/TestTaskService.Api.csproj"

# Copy the rest of the application and build
COPY . .
WORKDIR "/src/src/Services/TestTaskService/TestTaskService.Api/TestTaskService.Api"
RUN dotnet build "TestTaskService.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "TestTaskService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTaskService.Api.dll"]