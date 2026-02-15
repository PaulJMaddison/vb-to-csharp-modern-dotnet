# Stops processes started by run-lab.ps1 using ./.lab/pids.json.

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$labDir = Join-Path $root '.lab'
$pidsFile = Join-Path $labDir 'pids.json'

if (-not (Test-Path $pidsFile)) {
    Write-Host 'No lab PID file found. Nothing to stop.'
    exit 0
}

$entries = Get-Content $pidsFile -Raw | ConvertFrom-Json

foreach ($entry in $entries) {
    $pid = [int]$entry.PID
    $name = $entry.Name

    $proc = Get-Process -Id $pid -ErrorAction SilentlyContinue
    if ($null -eq $proc) {
        Write-Host "$name (PID $pid) is already stopped."
        continue
    }

    Write-Host "Stopping $name (PID $pid)..."

    # Graceful stop first.
    Stop-Process -Id $pid -ErrorAction SilentlyContinue
    Start-Sleep -Milliseconds 500

    # If still running, force stop.
    if (Get-Process -Id $pid -ErrorAction SilentlyContinue) {
        Stop-Process -Id $pid -Force -ErrorAction SilentlyContinue
    }
}

Remove-Item -Path $labDir -Recurse -Force -ErrorAction SilentlyContinue
Write-Host 'Lab stopped and .lab folder removed.'
