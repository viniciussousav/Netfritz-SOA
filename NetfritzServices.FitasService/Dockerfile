#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8082
EXPOSE 9082

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetfritzServices.FitasService/NetfritzServices.FitasService.csproj", "NetfritzServices.FitasService/"]
RUN dotnet restore "NetfritzServices.FitasService/NetfritzServices.FitasService.csproj"
COPY . .
WORKDIR "/src/NetfritzServices.FitasService"
RUN dotnet build "NetfritzServices.FitasService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetfritzServices.FitasService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetfritzServices.FitasService.dll"]