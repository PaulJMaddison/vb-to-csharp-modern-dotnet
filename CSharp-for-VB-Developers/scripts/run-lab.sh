#!/usr/bin/env bash
set -euo pipefail

# Starts the gateway + key APIs/UI apps on fixed HTTP ports.
# We force ports with ASPNETCORE_URLS so everyone in training uses the same URLs.

ROOT_DIR="$(cd "$(dirname "$0")/.." && pwd)"
LAB_DIR="$ROOT_DIR/.lab"
PIDS_FILE="$LAB_DIR/pids"

mkdir -p "$LAB_DIR"
: > "$PIDS_FILE"

start_service() {
  local name="$1"
  local project="$2"
  local port="$3"

  ASPNETCORE_URLS="http://localhost:${port}" dotnet run --project "$ROOT_DIR/$project" &
  local pid=$!

  echo "$name:$pid" >> "$PIDS_FILE"
}

echo "Starting lab services on fixed HTTP ports..."

start_service "Gateway" "src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj" "5080"
start_service "Web API" "src/11-WebApi-CleanArchitecture/WebApiClean.csproj" "5081"
start_service "Auth API" "src/08-WebApi-WithAuth/WebApiWithAuth.csproj" "5082"
start_service "Razor Pages" "src/03-WebApp-RazorPages/WebAppRazorPages.csproj" "5083"
start_service "MVC" "src/07-MvcWebApp/MvcWebApp.csproj" "5084"
start_service "Blazor" "src/06-BlazorWebApp/BlazorWebApp.csproj" "5085"

echo
echo "Lab started. Service summary:"
printf "%-12s %-24s %-32s %s\n" "Service" "URL" "Swagger" "Health"
printf "%-12s %-24s %-32s %s\n" "Gateway" "http://localhost:5080" "-" "http://localhost:5080/health"
printf "%-12s %-24s %-32s %s\n" "Web API" "http://localhost:5081" "http://localhost:5081/swagger" "http://localhost:5081/health"
printf "%-12s %-24s %-32s %s\n" "Auth API" "http://localhost:5082" "http://localhost:5082/swagger" "http://localhost:5082/health"
printf "%-12s %-24s %-32s %s\n" "Razor Pages" "http://localhost:5083" "-" "-"
printf "%-12s %-24s %-32s %s\n" "MVC" "http://localhost:5084" "-" "-"
printf "%-12s %-24s %-32s %s\n" "Blazor" "http://localhost:5085" "-" "-"
echo
echo "PID file: $PIDS_FILE"
echo "Gateway URL: http://localhost:5080"
