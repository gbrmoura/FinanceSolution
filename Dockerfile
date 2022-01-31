FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FinanceSolution.Interface/FinanceSolution.Interface.csproj", "FinanceSolution.Interface/"]
COPY ["FinanceSolution.Data/FinanceSolution.Data", "FinanceSolution.Data/"]
RUN dotnet restore "FinanceSolution.Interface/FinanceSolution.Interface.csproj"
RUN dotnet restore "FinanceSolution.Data/FinanceSolution.Data.csproj"
COPY . .
WORKDIR "/src/FinanceSolution.Interface"
RUN dotnet build "FinanceSolution.Interface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceSolution.Interface.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app/publish
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinanceSolution.Interface.dll"]