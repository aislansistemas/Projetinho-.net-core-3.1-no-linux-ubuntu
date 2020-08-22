FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
MAINTAINER Aislan Peixoto
WORKDIR /app
COPY . /var/www
ENTRYPOINT ["dotnet","run"]