FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY POS/bin/Release/netcoreapp3.0/publish/ POS/

CMD ASPNETCORE_URLS=http://*:$PORT dotnet POS/POS.dll