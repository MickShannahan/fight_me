FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY ./fight_me/bin/Release/net6.0/publish/ App/
WORKDIR /App
CMD ASPNETCORE_URLS=http://*:$PORT dotnet fight_me.dll
