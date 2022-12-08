FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# COPY ./bin/Release/net6.0/publish/ App/
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/sdk:6.0
# WORKDIR /App
# CMD ASPNETCORE_URLS=http://* fight_me.dll
ENTRYPOINT ["fight_me.dll"]
