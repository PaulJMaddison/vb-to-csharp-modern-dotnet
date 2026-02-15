# Reverse Proxy Gateway (YARP)

A gateway is a "front door" for clients. It can route traffic to multiple internal services.
This is useful for strangler migrations where legacy and modern services coexist.

`13-ReverseProxy-Gateway` forwards:
- `/api/*` to `11-WebApi-CleanArchitecture`
- `/auth/*` to `08-WebApi-WithAuth`
