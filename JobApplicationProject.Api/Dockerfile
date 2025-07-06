# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyalarını önce kopyala ve restore et (cache için)
COPY ["JobApplicationProject/JobApplicationProject.csproj", "JobApplicationProject/"]
COPY ["JobApplicationProject.Api/JobApplicationProject.Api.csproj", "JobApplicationProject.Api/"]
RUN dotnet restore "JobApplicationProject.Api/JobApplicationProject.Api.csproj"

# Tüm source kodunu kopyala
COPY . .
WORKDIR /src/JobApplicationProject.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "JobApplicationProject.Api.dll"]
