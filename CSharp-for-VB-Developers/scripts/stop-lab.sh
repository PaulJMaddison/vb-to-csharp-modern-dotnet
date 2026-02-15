#!/usr/bin/env bash
set -euo pipefail

# Stops processes started by run-lab.sh using ./.lab/pids.

ROOT_DIR="$(cd "$(dirname "$0")/.." && pwd)"
LAB_DIR="$ROOT_DIR/.lab"
PIDS_FILE="$LAB_DIR/pids"

if [[ ! -f "$PIDS_FILE" ]]; then
  echo "No lab PID file found. Nothing to stop."
  exit 0
fi

while IFS=: read -r name pid; do
  [[ -z "${pid:-}" ]] && continue

  if kill -0 "$pid" 2>/dev/null; then
    echo "Stopping $name (PID $pid)..."
    kill "$pid" 2>/dev/null || true
    sleep 1

    if kill -0 "$pid" 2>/dev/null; then
      kill -9 "$pid" 2>/dev/null || true
    fi
  else
    echo "$name (PID $pid) is already stopped."
  fi
done < "$PIDS_FILE"

rm -rf "$LAB_DIR"
echo "Lab stopped and .lab folder removed."
