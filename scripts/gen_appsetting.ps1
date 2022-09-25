param(

	[Parameter()]
	[string]$server = "127.0.0.1",
	
	[Parameter()]
	[string]$name,

	[Parameter()]
	[string]$uid = "sa",

	[Parameter()]
	[string]$pwd,
	
	[Parameter()]
	[bool]$Cloud = $false

)

$ConnectionName = If ($Cloud) {"BackupLocalDb"} Else {"LocalDb"}

$Object = @"
{"Logging": {"LogLevel": {"Default": "Information","Microsoft.AspNetCore": "Warning"}},"ConnectionStrings": {"$ConnectionName": "Server=$server;Database=$name;UID=$uid;PWD=$pwd"},"AllowedHosts": "*"}
"@


$FilePath = "../src/API/appsettings.json"

$Object = $Object | ConvertFrom-JSON

$JsonObject = $Object | ConvertTo-JSON -Depth 3

$JsonObject | Out-File $FilePath