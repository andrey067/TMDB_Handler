FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY TMDB_Handler/Tmdb.API/Tmdb.API.csproj /Tmdb.API/
COPY TMDB_Handler/Tmdb.Core/Tmdb.Core.csproj /Tmdb.Core/
COPY TMDB_Handler/Tmdb.CrossCutting/Tmdb.CrossCutting.csproj /Tmdb.CrossCutting/
COPY TMDB_Handler/Tmdb.Domain/Tmdb.Domain.csproj /Tmdb.Domain/
COPY TMDB_Handler/Tmdb.Infra/Tmdb.Infra.csproj /Tmdb.Infra/
COPY TMDB_Handler/Tmdb.Services/Tmdb.Services.csproj /Tmdb.Services/

RUN dotnet restore /Tmdb.API/Tmdb.API.csproj
COPY . ./
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app/published-app /app
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Tmdb.API.dll
# ENTRYPOINT [ "dotnet", "Tmdb.API.dll" ]