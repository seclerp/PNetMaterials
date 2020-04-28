FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY SensorFusion.Shared.Data/SensorFusion.Shared.Data.csproj SensorFusion.Shared.Data/
COPY SensorFusion.Web.App/SensorFusion.Web.App.csproj SensorFusion.Web.App/
RUN dotnet restore SensorFusion.Web.App/SensorFusion.Web.App.csproj
COPY . .
WORKDIR /src/SensorFusion.Web.App
RUN dotnet build SensorFusion.Web.App.csproj -c Release -o /app

FROM build AS publish
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_8.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm
RUN dotnet publish SensorFusion.Web.App.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SensorFusion.Web.App.dll"]