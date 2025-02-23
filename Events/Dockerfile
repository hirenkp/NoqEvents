# Stage 1: Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
# Run as the non-root user provided by the image (the app user with UID from $APP_UID)
USER $APP_UID
WORKDIR /app
# Expose the port that the container will listen on (default for .NET 9 is 8080)
EXPOSE 8080
# Ensure the app binds to all interfaces on port 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Stage 2: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copy the project file and restore dependencies
COPY ["Events/Events.csproj", "Events/"]
RUN dotnet restore "Events/Events.csproj"
# Copy the remaining source code
COPY . .
WORKDIR "/src/Events"
# Build the application in the specified configuration
RUN dotnet build "Events.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# Publish as a framework‑dependent deployment without generating an app host
RUN dotnet publish "Events.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final runtime image
FROM base AS final
WORKDIR /app
# Copy the published output from the publish stage
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Events.dll"]
