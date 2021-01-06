#Dockerfile
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS builder
WORKDIR /src
COPY ./JWTTTTT.csproj .
RUN dotnet restore JWTTTTT.csproj
COPY . .
RUN dotnet build JWTTTTT.csproj -c Debug -o /src/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY --from=builder /src/out .

EXPOSE 5000
ENTRYPOINT ["dotnet", "JWTTTTT.dll"]

