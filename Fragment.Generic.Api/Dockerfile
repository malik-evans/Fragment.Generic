FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Fragment.Generic.Api/*.csproj ./Fragment.Generic.Api/
RUN dotnet restore Fragment.Generic.Api/Fragment.Generic.Api.csproj

# copy everything else and build app
COPY Fragment.Generic.Api/ ./Fragment.Generic.Api/
WORKDIR /app/Fragment.Generic.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/Fragment.Generic.Api/out ./
ENTRYPOINT ["dotnet","Fragment.Generic.Api.dll"]
