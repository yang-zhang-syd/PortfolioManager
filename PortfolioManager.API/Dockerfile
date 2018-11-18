FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 56437
EXPOSE 44348

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["PortfolioManager/PortfolioManager.csproj", "PortfolioManager/"]
RUN dotnet restore "PortfolioManager/PortfolioManager.csproj"
COPY . .
WORKDIR "/src/PortfolioManager"
RUN dotnet build "PortfolioManager.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PortfolioManager.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PortfolioManager.dll"]