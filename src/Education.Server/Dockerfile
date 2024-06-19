FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /
COPY "src/" "src"
WORKDIR /src/Education.Server
RUN apt-get update -y
RUN apt-get install -y python3
RUN dotnet workload restore
RUN dotnet publish Education.Server.csproj -c Release -o /app --os linux --arch x64

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Education.Server.dll"]
