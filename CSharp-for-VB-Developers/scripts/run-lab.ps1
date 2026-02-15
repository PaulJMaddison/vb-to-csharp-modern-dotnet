param(
    [switch]$OpenBrowser
)

# Starts the gateway + key APIs/UI apps on fixed HTTP ports.
# We force ports with ASPNETCORE_URLS so everyone in training uses the same URLs.

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$labDir = Join-Path $root '.lab'
$pidsFile = Join-Path $labDir 'pids.json'

New-Item -ItemType Directory -Path $labDir -Force | Out-Null

$services = @(
    [pscustomobject]@{ Name = 'Gateway';      Project = 'src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj'; Port = 5080; Swagger = '';                  Health = '/health' },
    [pscustomobject]@{ Name = 'Web API';      Project = 'src/11-WebApi-CleanArchitecture/WebApiClean.csproj';      Port = 5081; Swagger = '/swagger';          Health = '/health' },
    [pscustomobject]@{ Name = 'Auth API';     Project = 'src/08-WebApi-WithAuth/WebApiWithAuth.csproj';             Port = 5082; Swagger = '/swagger';          Health = '/health' },
    [pscustomobject]@{ Name = 'Razor Pages';  Project = 'src/03-WebApp-RazorPages/WebAppRazorPages.csproj';         Port = 5083; Swagger = '';                  Health = '' },
    [pscustomobject]@{ Name = 'MVC';          Project = 'src/07-MvcWebApp/MvcWebApp.csproj';                        Port = 5084; Swagger = '';                  Health = '' },
    [pscustomobject]@{ Name = 'Blazor';       Project = 'src/06-BlazorWebApp/BlazorWebApp.csproj';                  Port = 5085; Swagger = '';                  Health = '' }
)

Write-Host 'Starting lab services on fixed HTTP ports...'

$originalUrls = $env:ASPNETCORE_URLS
$started = @()

foreach ($svc in $services) {
    $url = "http://localhost:$($svc.Port)"

    # Set ASPNETCORE_URLS before each process starts.
    $env:ASPNETCORE_URLS = $url

    $proc = Start-Process dotnet -ArgumentList "run --project $($svc.Project)" -WorkingDirectory $root -PassThru

    $started += [pscustomobject]@{
        Name       = $svc.Name
        Project    = $svc.Project
        Url        = $url
        SwaggerUrl = if ($svc.Swagger) { "$url$($svc.Swagger)" } else { '-' }
        HealthUrl  = if ($svc.Health) { "$url$($svc.Health)" } else { '-' }
        PID        = $proc.Id
    }
}

# Restore caller environment variable.
$env:ASPNETCORE_URLS = $originalUrls

$started | ConvertTo-Json | Set-Content -Path $pidsFile -Encoding UTF8

Write-Host ''
Write-Host 'Lab started. Service summary:'
$started | Select-Object Name, Url, SwaggerUrl, HealthUrl, PID | Format-Table -AutoSize
Write-Host ''
Write-Host "PID file: $pidsFile"
Write-Host "Gateway URL: http://localhost:5080"

if ($OpenBrowser) {
    Start-Process 'http://localhost:5080'
}
