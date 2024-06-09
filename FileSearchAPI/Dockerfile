FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FileSearchAPI.csproj", "."]
RUN dotnet restore "FileSearchAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "FileSearchAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileSearchAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["sh", "-c", "echo ASPNETCORE_URLS=$ASPNETCORE_URLS && dotnet FileSearchAPI.dll"]
