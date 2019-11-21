FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build-env
WORKDIR /app

# Copy everything else and build
COPY ConferenceService/ ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ConferenceService.dll"]

EXPOSE 80
