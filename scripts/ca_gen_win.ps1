param(
	[Parameter()]
	[string]$P
)


dotnet dev-certs https --clean
dotnet dev-certs https -ep $env:UserProfile\.aspnet\https\aspnetapp.pfx -p $P
dotnet dev-certs https --trust