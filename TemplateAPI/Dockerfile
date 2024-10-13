FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TemplateAPI/TemplateAPI.csproj", "./"]
RUN dotnet restore "./TemplateAPI.csproj"
COPY . .
WORKDIR "/src/TemplateAPI"
RUN dotnet build "TemplateAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TemplateAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemplateAPI.dll"]
