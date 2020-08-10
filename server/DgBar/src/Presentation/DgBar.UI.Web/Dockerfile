#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Presentation/DgBar.UI.Web/DgBar.UI.Web.csproj", "src/Presentation/DgBar.UI.Web/"]
RUN dotnet restore "src/Presentation/DgBar.UI.Web/DgBar.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/Presentation/DgBar.UI.Web"
RUN dotnet build "DgBar.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DgBar.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DgBar.UI.Web.dll"]