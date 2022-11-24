#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GasInfoApi/GasInfoApi.csproj", "GasInfoApi/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["DA/DA.csproj", "DA/"]
RUN dotnet restore "GasInfoApi/GasInfoApi.csproj"
COPY . .
WORKDIR "/src/GasInfoApi"
RUN dotnet build "GasInfoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GasInfoApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GasInfoApi.dll"]