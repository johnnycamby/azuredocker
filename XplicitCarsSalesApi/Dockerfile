FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY XplicitCarsSalesApi/XplicitCarsSalesApi.csproj XplicitCarsSalesApi/
RUN dotnet restore XplicitCarsSalesApi/XplicitCarsSalesApi.csproj
COPY . .
WORKDIR /src/XplicitCarsSalesApi
RUN dotnet build XplicitCarsSalesApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish XplicitCarsSalesApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "XplicitCarsSalesApi.dll"]
