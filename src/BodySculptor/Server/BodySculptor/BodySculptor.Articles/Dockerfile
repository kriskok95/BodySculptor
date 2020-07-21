#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BodySculptor.Articles/BodySculptor.Articles.csproj", "BodySculptor.Articles/"]
COPY ["BodySculptor.Services.Mapping/BodySculptor.Services.Mapping.csproj", "BodySculptor.Services.Mapping/"]
COPY ["BodySculptor.Common/BodySculptor.Common.csproj", "BodySculptor.Common/"]
RUN dotnet restore "BodySculptor.Articles/BodySculptor.Articles.csproj"
COPY . .
WORKDIR "/src/BodySculptor.Articles"
RUN dotnet build "BodySculptor.Articles.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "BodySculptor.Articles.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BodySculptor.Articles.dll"]