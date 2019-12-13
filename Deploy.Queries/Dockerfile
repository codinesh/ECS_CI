FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Deploy.Queries/Deploy.Queries.csproj", "Deploy.Queries/"]
RUN dotnet restore "Deploy.Queries/Deploy.Queries.csproj"
COPY . .
WORKDIR "/src/Deploy.Queries"
RUN dotnet build "Deploy.Queries.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deploy.Queries.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deploy.Queries.dll"]