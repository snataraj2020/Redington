FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51382
EXPOSE 44391

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY RedingtonCalculator.Web/RedingtonCalculator.Web.csproj RedingtonCalculator.Web/
RUN dotnet restore RedingtonCalculator.Web/RedingtonCalculator.Web.csproj
COPY . .
WORKDIR /src/RedingtonCalculator.Web
RUN dotnet build RedingtonCalculator.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RedingtonCalculator.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
WORKDIR /app/Logs
EXPOSE 80
EXPOSE 2222
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RedingtonCalculator.Web.dll"]
