echo .
echo Make sure to create LetsEncrypt certificate for testing purposes and put it into $HOME/.cert/adventure-works.com.pfx
echo .
export ASPNETCORE_Kestrel__Certificates__Default__Password=X
export ASPNETCORE_Kestrel__Certificates__Default__Path=$HOME/.cert/adventure-works.com.pfx
export DOTNET_ENVIRONMENT=Staging
export ASPNETCORE_ENVIRONMENT=Staging
export ASPNETCORE_URLS=https://+:443;http://+:80
dotnet run watch --no-launch-profile