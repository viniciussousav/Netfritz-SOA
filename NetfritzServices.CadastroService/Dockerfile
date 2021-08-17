

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetfritzServices.CadastroService/NetfritzServices.CadastroService.csproj", "NetfritzServices.CadastroService/"]
RUN dotnet restore "NetfritzServices.CadastroService/NetfritzServices.CadastroService.csproj"
COPY . .
WORKDIR "/src/NetfritzServices.CadastroService"
RUN dotnet build "NetfritzServices.CadastroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetfritzServices.CadastroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetfritzServices.CadastroService.dll"]
