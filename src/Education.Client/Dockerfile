FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . ./
RUN apt-get update -y
RUN apt-get install -y python3
RUN dotnet workload install wasm-tools
RUN dotnet publish Education.Client -c Release -o /app

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build /app/wwwroot .
COPY Education.Client/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
