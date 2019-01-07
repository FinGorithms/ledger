SET subkey1=%random%%random%%random%%random%%random%%random%

dotnet ef database drop --force
del /f /q .\migrations\*
dotnet ef migrations add %subkey1%
dotnet ef database update 