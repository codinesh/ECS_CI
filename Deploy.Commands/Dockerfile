FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Deploy.Commands/Deploy.Commands.csproj", "Deploy.Commands/"]
RUN dotnet restore "Deploy.Commands/Deploy.Commands.csproj"
COPY . .
WORKDIR "/src/Deploy.Commands"
RUN dotnet build "Deploy.Commands.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deploy.Commands.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deploy.Commands.dll"]