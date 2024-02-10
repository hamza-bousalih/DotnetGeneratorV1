dotnet --version
dotnet tool install --global dotnet-ef --version 7.0.0
dotnet ef migrations add Init
dotnet ef database update
