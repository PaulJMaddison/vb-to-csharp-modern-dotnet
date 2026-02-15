using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

public class WebApiCleanTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetVersion_ReturnsOk_WithExpectedFields()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/version");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<JsonObject>();
        Assert.NotNull(body);
        Assert.False(string.IsNullOrWhiteSpace(body["application"]?.GetValue<string>()));
        Assert.False(string.IsNullOrWhiteSpace(body["version"]?.GetValue<string>()));
        Assert.False(string.IsNullOrWhiteSpace(body["environment"]?.GetValue<string>()));
    }

    [Fact]
    public async Task PostCustomer_WithInvalidPayload_ReturnsProblemDetailsShape()
    {
        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/customers", new { Name = "", Email = "invalid" });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var problem = await response.Content.ReadFromJsonAsync<JsonObject>();
        Assert.NotNull(problem);
        Assert.Equal("Validation failed", problem["title"]?.GetValue<string>());
        Assert.Equal(400, problem["status"]?.GetValue<int>());
        Assert.Equal("https://tools.ietf.org/html/rfc9110#section-15.5.1", problem["type"]?.GetValue<string>());
        Assert.NotNull(problem["errors"]);
    }

    [Fact]
    public async Task RequestWithCorrelationId_EchoesHeaderInResponse()
    {
        const string correlationHeaderName = "X-Correlation-ID";
        const string correlationId = "test-123";

        var client = factory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/version");
        request.Headers.Add(correlationHeaderName, correlationId);

        var response = await client.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.True(response.Headers.TryGetValues(correlationHeaderName, out var values));
        Assert.Equal(correlationId, Assert.Single(values));
    }
}
