@echo off
taskkill /F /IM EnglishApp.exe > nul 2>&1
dotnet clean
dotnet build
dotnet run