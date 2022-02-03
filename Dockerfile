FROM microsoft/dotnet:3.1-sdk-alpine AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Wordle/*.csproj ./wordle/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/wordle
RUN dotnet build
 
FROM build AS publish
WORKDIR /app/wordle
RUN dotnet publish -c Release -o out  

FROM microsoft/dotnet:3.1-aspnetcore-runtime-alpine AS runtime
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
WORKDIR /app
COPY --from=publish /app/wordle/out ./
ENTRYPOINT ["dotnet", "Wordle.dll"]