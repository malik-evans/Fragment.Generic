FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Fragment.Generic.App/*.csproj ./Fragment.Generic.App/
RUN dotnet restore Fragment.Generic.App/Fragment.Generic.App.csproj

# copy everything else and build app
COPY Fragment.Generic.App/ ./Fragment.Generic.App/
WORKDIR /app/Fragment.Generic.App
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/Fragment.Generic.App/out ./
ENTRYPOINT ["dotnet","Fragment.Generic.App.dll"]
