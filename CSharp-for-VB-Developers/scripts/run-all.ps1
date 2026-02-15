Write-Host "Starting APIs + gateway for local learning..."

$root = Split-Path -Parent $PSScriptRoot

Start-Process dotnet -ArgumentList "run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj" -WorkingDirectory $root
Start-Process dotnet -ArgumentList "run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj" -WorkingDirectory $root
Start-Process dotnet -ArgumentList "run --project src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj" -WorkingDirectory $root

Write-Host "Started projects."
Write-Host "Auth API:    http://localhost:5222"
Write-Host "Clean API:   http://localhost:5111"
Write-Host "Gateway:     http://localhost:5000"
