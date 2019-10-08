#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["supportupdateAPI/supportupdateAPI.csproj", "supportupdateAPI/"]
RUN dotnet restore "supportupdateAPI/supportupdateAPI.csproj"
COPY . .
WORKDIR "/src/supportupdateAPI"
RUN dotnet build "supportupdateAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "supportupdateAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "supportupdateAPI.dll"]