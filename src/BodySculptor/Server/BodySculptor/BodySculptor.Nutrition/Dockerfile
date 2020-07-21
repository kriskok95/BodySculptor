#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BodySculptor.Nutrition/BodySculptor.Nutrition.csproj", "BodySculptor.Nutrition/"]
COPY ["BodySculptor.Services.Mapping/BodySculptor.Services.Mapping.csproj", "BodySculptor.Services.Mapping/"]
COPY ["BodySculptor.Common/BodySculptor.Common.csproj", "BodySculptor.Common/"]
RUN dotnet restore "BodySculptor.Nutrition/BodySculptor.Nutrition.csproj"
COPY . .
WORKDIR "/src/BodySculptor.Nutrition"
RUN dotnet build "BodySculptor.Nutrition.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "BodySculptor.Nutrition.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BodySculptor.Nutrition.dll"]