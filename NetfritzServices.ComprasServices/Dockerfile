#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8083
EXPOSE 9083

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetfritzServices.ComprasServices/NetfritzServices.ComprasServices.csproj", "NetfritzServices.ComprasServices/"]
RUN dotnet restore "NetfritzServices.ComprasServices/NetfritzServices.ComprasServices.csproj"
COPY . .
WORKDIR "/src/NetfritzServices.ComprasServices"
RUN dotnet build "NetfritzServices.ComprasServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetfritzServices.ComprasServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetfritzServices.ComprasServices.dll"]