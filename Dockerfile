FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MarsRover.ConsoleApp/MarsRover.ConsoleApp.csproj", "MarsRover.ConsoleApp/"]
COPY ["MarsRover.Library/MarsRover.Library.csproj", "MarsRover.Library/"]
RUN dotnet restore "MarsRover.ConsoleApp/MarsRover.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/MarsRover.ConsoleApp"
RUN dotnet build "MarsRover.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarsRover.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarsRover.ConsoleApp.dll"]