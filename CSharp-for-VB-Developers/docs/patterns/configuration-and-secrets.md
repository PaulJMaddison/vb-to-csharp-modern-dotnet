# Configuration and Secrets

Store app settings in `appsettings.json`, environment-specific overrides, and environment variables.
Do **not** hardcode production secrets in source code.

Use local secret stores (`dotnet user-secrets`) for development and managed secret stores in production.
