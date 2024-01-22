FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base 

WORKDIR /app 

EXPOSE 80 

EXPOSE 443 

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build 

ARG BUILD_CONFIGURATION=Release 

WORKDIR /src 

COPY ["Note.API/Note.API.csproj", "Note/Note.API/"]
COPY ["Note.Application/Note.Application.csproj", "Note/Note.Application/"]
COPY ["Note.Infrastructure/Note.Infrastructure.csproj", "Note/Note.Infrastructure/"]
COPY ["Note.Core/Note.Core.csproj", "Note/Note.Core/"]
RUN dotnet restore "Note/Note.API/Note.API.csproj"
COPY . .
WORKDIR "/src/Note.API"
RUN dotnet build "Note.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Note.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Note.API.dll"]