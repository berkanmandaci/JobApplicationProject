# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projeleri ve bağımlılık projelerini kopyala
COPY JobApplicationProject/ JobApplicationProject/
COPY JobApplicationProject.Api/ JobApplicationProject.Api/

WORKDIR /src/JobApplicationProject.Api
RUN dotnet restore

RUN dotnet publish -c Release -o /app/publish

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "JobApplicationProject.Api.dll"]
