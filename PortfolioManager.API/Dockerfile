FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["PortfolioManager.API/PortfolioManager.API.csproj", "PortfolioManager.API/"]
RUN dotnet restore "PortfolioManager.API/PortfolioManager.API.csproj"
COPY . .
WORKDIR "/src/PortfolioManager.API"
RUN dotnet build "PortfolioManager.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PortfolioManager.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PortfolioManager.API.dll"]