# Build and publish stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /build
COPY ./ItemsApi/items-api.csproj .
RUN dotnet restore
COPY ./ItemsApi/src/ ./src/
COPY ./ItemsApi/appsettings.json .
RUN dotnet publish -c Release -o ./publish

# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
EXPOSE 3000
COPY --from=build /build/publish .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "items-api.dll", "--urls", "http://0.0.0.0:3000"]