# docker-compose-netcore


.NET Core 3.1 + SQL + Docker-Compose 
 
dotnet restore
dotnet build


docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password2021' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
