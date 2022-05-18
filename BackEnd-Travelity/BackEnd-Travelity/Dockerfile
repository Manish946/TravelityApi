#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackEnd-Travelity/BackEnd-Travelity.csproj", "BackEnd-Travelity/"]
RUN dotnet restore "BackEnd-Travelity/BackEnd-Travelity.csproj"
COPY . .
WORKDIR "/src/BackEnd-Travelity"
RUN dotnet build "BackEnd-Travelity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackEnd-Travelity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackEnd-Travelity.dll"]