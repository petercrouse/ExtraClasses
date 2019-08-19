FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ExtraClasses.Api/ExtraClasses.Api.csproj", "ExtraClasses.Api/"]
RUN dotnet restore "ExtraClasses.Api/ExtraClasses.Api.csproj"
COPY . .
WORKDIR "/src/ExtraClasses.Api"
RUN dotnet build "ExtraClasses.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ExtraClasses.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ExtraClasses.Api.dll"]