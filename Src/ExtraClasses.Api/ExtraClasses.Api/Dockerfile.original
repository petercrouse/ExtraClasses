FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ExtraClasses.Api/ExtraClasses.Api.csproj", "ExtraClasses.Api/"]
COPY ["ExtraClasses.Infrastructure/ExtraClasses.Infrastructure.csproj", "ExtraClasses.Infrastructure/"]
COPY ["ExtraClasses.Application/ExtraClasses.Application.csproj", "ExtraClasses.Application/"]
COPY ["ExtraClasses.Common/ExtraClasses.Common.csproj", "ExtraClasses.Common/"]
COPY ["ExtraClasses.Domain/ExtraClasses.Domain.csproj", "ExtraClasses.Domain/"]
COPY ["ExtraClasses.Persistence/ExtraClasses.Persistence.csproj", "ExtraClasses.Persistence/"]
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