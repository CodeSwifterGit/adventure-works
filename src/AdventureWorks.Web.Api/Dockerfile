FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS restored
WORKDIR /src
COPY . .
RUN dotnet restore /src/src/AdventureWorks.Web.Api/AdventureWorks.Web.Api.csproj
RUN dotnet restore /src/src/AdventureWorks.Application.Tests/AdventureWorks.Application.Tests.csproj

FROM restored AS publish
ARG GIT_COMMIT=0
ARG BUILD_NUMBER=0
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/src/AdventureWorks.Web.Api"
RUN dotnet publish "AdventureWorks.Web.Api.csproj" -c $BUILD_CONFIGURATION  -p:VersionPrefix=1.0.0 -p:VersionSuffix=$BUILD_NUMBER -p:SourceRevisionId=$GIT_COMMIT -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV USE_HSTS false
ENTRYPOINT ["dotnet", "AdventureWorks.Web.Api"]