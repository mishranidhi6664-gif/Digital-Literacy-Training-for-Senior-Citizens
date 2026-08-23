# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["Digital Literacy Training for Senior Citizens/Digital Literacy Training for Senior Citizens.csproj", "Digital Literacy Training for Senior Citizens/"]

RUN dotnet restore "Digital Literacy Training for Senior Citizens/Digital Literacy Training for Senior Citizens.csproj"

COPY . .

WORKDIR "/src/Digital Literacy Training for Senior Citizens"

RUN dotnet publish "Digital Literacy Training for Senior Citizens.csproj" -c Release -o /app/publish /p:UseAppHost=false


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "Digital Literacy Training for Senior Citizens.dll"]