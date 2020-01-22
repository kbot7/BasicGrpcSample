FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app "./BasicGrpcSample.Server/BasicGrpcSample.Server.csproj"

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
EXPOSE 5001
COPY --from=build /app .
ENTRYPOINT ["dotnet", "BasicGrpcSample.Server.dll"]