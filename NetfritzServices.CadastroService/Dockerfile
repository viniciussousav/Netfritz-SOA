FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetfritzCadastroService/NetfritzCadastroService.csproj", "NetfritzCadastroService/"]
RUN dotnet restore "NetfritzCadastroService/NetfritzCadastroService.csproj"
COPY . .
WORKDIR "/src/NetfritzCadastroService"
RUN dotnet build "NetfritzCadastroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetfritzCadastroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetfritzCadastroService.dll"]
