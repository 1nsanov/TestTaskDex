FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["tools/TestTaskDex.Migrator/TestTaskDex.Migrator.csproj", "tools/TestTaskDex.Migrator/"]
COPY ["src/Services/TestTaskService/TestTaskService.Infrastructure/TestTaskService.Infrastructure/TestTaskService.Infrastructure.csproj", "src/Services/TestTaskService/TestTaskService.Infrastructure/TestTaskService.Infrastructure/"]
COPY ["src/Services/TestTaskService/TestTaskService.Domain/TestTaskService.Domain/TestTaskService.Domain.csproj", "src/Services/TestTaskService/TestTaskService.Domain/TestTaskService.Domain/"]
RUN dotnet restore "tools/TestTaskDex.Migrator/TestTaskDex.Migrator.csproj"
COPY . .
WORKDIR "/src/tools/TestTaskDex.Migrator"
RUN dotnet build "TestTaskDex.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTaskDex.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTaskDex.Migrator.dll"]
