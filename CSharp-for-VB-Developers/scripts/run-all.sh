#!/usr/bin/env bash
set -euo pipefail

echo "Starting APIs + gateway for local learning..."

ROOT_DIR="$(cd "$(dirname "$0")/.." && pwd)"

dotnet run --project "$ROOT_DIR/src/08-WebApi-WithAuth/WebApiWithAuth.csproj" &
PID_AUTH=$!
dotnet run --project "$ROOT_DIR/src/11-WebApi-CleanArchitecture/WebApiClean.csproj" &
PID_CLEAN=$!
dotnet run --project "$ROOT_DIR/src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj" &
PID_GATEWAY=$!

trap 'kill $PID_AUTH $PID_CLEAN $PID_GATEWAY 2>/dev/null || true' EXIT

echo "Auth API:    http://localhost:5222"
echo "Clean API:   http://localhost:5111"
echo "Gateway:     http://localhost:5000"
echo "Press Ctrl+C to stop all processes."
wait
