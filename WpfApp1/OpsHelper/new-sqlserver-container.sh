#!/bin/bash
docker rm -f HelloWorld-sqlserver;

#brand new sqlServer Container
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=passw0rD!" -p 1433:1433 --name  HelloWorld-sqlserver -d mcr.microsoft.com/mssql/server;