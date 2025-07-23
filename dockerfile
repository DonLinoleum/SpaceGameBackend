FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SpaceGameBackend.csproj","."]
RUN dotnet restore

COPY . .
WORKDIR /src
RUN dotnet build "SpaceGameBackend.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS final
WORKDIR /app/build
COPY --from=build /app/build .

WORKDIR /app/src
COPY --from=build /src .

RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
WORKDIR /app/build/
ENTRYPOINT ["dotnet","SpaceGameBackend.dll"]