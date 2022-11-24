#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5003
ENV ASPNETCORE_URLS=http://*:5003

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GasInfoAdmin/GasInfoAdmin.csproj", "GasInfoAdmin/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["DA/DA.csproj", "DA/"]
RUN dotnet restore "GasInfoAdmin/GasInfoAdmin.csproj"
COPY . .
WORKDIR "/src/GasInfoAdmin"
RUN dotnet build "GasInfoAdmin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GasInfoAdmin.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GasInfoAdmin.dll"]