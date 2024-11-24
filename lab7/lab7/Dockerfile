FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lab7/Lab7.csproj", "Lab7/"]
RUN dotnet restore "Lab7/Lab7.csproj"
COPY . .
WORKDIR "/src/Lab7"
RUN dotnet build -c Release -o /app/build

# Публікація
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Фінальний образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab7.dll"]
