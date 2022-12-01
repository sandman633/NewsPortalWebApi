#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NewsPortal.WebApi/NewsPortal.WebApi.csproj", "NewsPortal.WebApi/"]
COPY ["NewsPortal.BusinessLogic/NewsPortal.BusinessLogic.csproj", "NewsPortal.BusinessLogic/"]
COPY ["NewsPortal.Repositories/NewsPortal.Repositories.csproj", "NewsPortal.Repositories/"]
COPY ["NewsPortal.DAL/NewsPortal.DAL.csproj", "NewsPortal.DAL/"]
COPY ["NewsPortal.Model/NewsPortal.Model.csproj", "NewsPortal.Model/"]
RUN dotnet restore "NewsPortal.WebApi/NewsPortal.WebApi.csproj"
COPY . .
WORKDIR "/src/NewsPortal.WebApi"
RUN dotnet build "NewsPortal.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewsPortal.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsPortal.WebApi.dll"]