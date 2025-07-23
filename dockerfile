FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SpaceGameBackend.csproj","."]
RUN dotnet restore

COPY . .
WORKDIR /src
RUN dotnet build "SpaceGameBackend.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/build /app
ENTRYPOINT ["dotnet","SpaceGameBackend.dll"]