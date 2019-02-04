FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY XplicitCarsStore/XplicitCarsStore.csproj XplicitCarsStore/
RUN dotnet restore XplicitCarsStore/XplicitCarsStore.csproj
COPY . .
WORKDIR /src/XplicitCarsStore
RUN dotnet build XplicitCarsStore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish XplicitCarsStore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "XplicitCarsStore.dll"]
