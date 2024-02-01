FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# TÜİK Sertifikası
COPY tuik-dc4-ca-pem.crt /usr/local/share/ca-certificates/extras/
RUN chmod 644 /usr/local/share/ca-certificates/extras/tuik-dc4-ca-pem.crt && update-ca-certificates

# Copy csproj and restore as distinct layers
COPY promet.csproj .
RUN dotnet restore promet.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish promet.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim
WORKDIR /app
#build-env aliası veriyoruz yukarıda ordan çağırıyoruz: Orda oluşturulan dosyaları /app/out klasörünü kopyala demiş oluyoruz.
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet" , "promet.dll"]