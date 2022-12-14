#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/PBL4.Web/PBL4.Web.csproj", "src/PBL4.Web/"]
COPY ["src/PBL4.Application/PBL4.Application.csproj", "src/PBL4.Application/"]
COPY ["src/PBL4.Domain/PBL4.Domain.csproj", "src/PBL4.Domain/"]
COPY ["src/PBL4.Domain.Shared/PBL4.Domain.Shared.csproj", "src/PBL4.Domain.Shared/"]
COPY ["src/PBL4.Application.Contracts/PBL4.Application.Contracts.csproj", "src/PBL4.Application.Contracts/"]
COPY ["src/PBL4.EntityFrameworkCore/PBL4.EntityFrameworkCore.csproj", "src/PBL4.EntityFrameworkCore/"]
RUN dotnet restore "src/PBL4.Web/PBL4.Web.csproj"
COPY . .
WORKDIR "/src/src/PBL4.Web"
RUN dotnet build "PBL4.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PBL4.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PBL4.Web.dll"]