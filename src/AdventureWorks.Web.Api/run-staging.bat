echo .
echo Make sure to create WILDCARD LetsEncrypt certificate for testing purposes and put it into %USERPROFILE%\.cert\adventure-works.com.pfx
echo .
SET ASPNETCORE_Kestrel__Certificates__Default__Password=X
set ASPNETCORE_Kestrel__Certificates__Default__Path=%USERPROFILE%\.cert\adventure-works.com.pfx
SET DOTNET_ENVIRONMENT=Staging
SET ASPNETCORE_ENVIRONMENT=Staging
SET ASPNETCORE_URLS=https://+:443;http://+:80
dotnet run watch --no-launch-profile