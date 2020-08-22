#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY StockRankDataPull/StockRankDataPull.csproj StockRankDataPull/
RUN dotnet restore "StockRankDataPull/StockRankDataPull.csproj"
COPY . .
WORKDIR "/src/StockRankDataPull"
RUN dotnet build "StockRankDataPull.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockRankDataPull.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockRankDataPull.dll"]
