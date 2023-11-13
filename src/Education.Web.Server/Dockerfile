FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /
COPY "src/" "src"
WORKDIR /src/Education.Web.Server
RUN dotnet publish Education.Web.Server.csproj -c Release -o /app --os linux --arch x64

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Education.Web.Server.dll"]
