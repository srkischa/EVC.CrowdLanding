FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY EVC.CrowdLanding.Api/EVC.CrowdLanding.Api.csproj EVC.CrowdLanding.Api/
COPY EVC.CrowdLanding.DomainModel/EVC.CrowdLanding.DomainModel.csproj EVC.CrowdLanding.DomainModel/
COPY EVC.CrowdLanding.Service/EVC.CrowdLanding.Service.csproj EVC.CrowdLanding.Service/
COPY EVC.CrowdLanding.Data/EVC.CrowdLanding.Data.csproj EVC.CrowdLanding.Data/
RUN dotnet restore EVC.CrowdLanding.Api/EVC.CrowdLanding.Api.csproj
COPY . .
WORKDIR /src/EVC.CrowdLanding.Api
RUN dotnet build EVC.CrowdLanding.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EVC.CrowdLanding.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EVC.CrowdLanding.Api.dll"]
