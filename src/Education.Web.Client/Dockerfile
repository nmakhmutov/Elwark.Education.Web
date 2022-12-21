FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . ./

RUN apt-get update -y
RUN apt-get install -y python3
RUN dotnet workload install wasm-tools
RUN dotnet publish src/Education.Web.Client/Education.Web.Client.csproj -c Release -o /app

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build /app/wwwroot .
COPY src/Education.Web.Client/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
