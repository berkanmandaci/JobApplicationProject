FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Proje dosyalarını önce kopyala ve restore et (cache için)
COPY ["JobApplicationProject/JobApplicationProject.csproj", "JobApplicationProject/"]
COPY ["UI/UI.csproj", "UI/"]
RUN dotnet restore "UI/UI.csproj"

# Tüm source kodunu kopyala
COPY . .
WORKDIR "/src/UI"
RUN dotnet build "UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UI.dll"]

# NOT: Bu Dockerfile, build context ana dizin (JobApplicationProject) olacak şekilde kullanılmalıdır.