# Testing: Unit vs Integration

- **Unit test**: isolated class/function, mocks dependencies, very fast.
- **Integration test**: runs multiple layers together (routing + serialization + DI + middleware).

`12-IntegrationTests` uses `WebApplicationFactory` to test API behavior without external infrastructure.
