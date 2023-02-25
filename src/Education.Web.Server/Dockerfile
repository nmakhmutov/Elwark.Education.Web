FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
RUN apt-get update -y
RUN apt-get install -y python3
RUN dotnet workload install wasm-tools
COPY ["src/Education.Web.Server/Education.Web.Server.csproj", "src/Education.Web.Server/"]
RUN dotnet restore "src/Education.Web.Server/Education.Web.Server.csproj"
COPY . .
WORKDIR "/src/src/Education.Web.Server"
RUN dotnet build "Education.Web.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Education.Web.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Education.Web.Server.dll"]
