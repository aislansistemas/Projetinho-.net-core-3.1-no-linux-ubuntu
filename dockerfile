FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
MAINTAINER Aislan Peixoto
WORKDIR /app
COPY ./dist .
ENTRYPOINT ["dotnet","testelinux.dll"]
