#Build stage

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./WebApplication1/WebApplication1.csproj"
RUN dotnet publish "./WebApplication1/WebApplication1.csproj" -c Release -o /publish --no-restore


#Server stage

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final

WORKDIR /app
COPY --from=build /publish .
WORKDIR /app/Firebase
COPY --from=build /src/Firebase .

WORKDIR /app

ENTRYPOINT [ "dotnet", "WebApplication1.dll", "--environment=Development"]

