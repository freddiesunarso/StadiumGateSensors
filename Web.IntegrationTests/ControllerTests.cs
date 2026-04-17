using Application.Gates.Commands.PublishAddGateAccessEvent;
using Application.Gates.Queries.GetSensorResults;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Web.IntegrationTests
{
    public class ControllerTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact]
        public async Task PostAndGet()
        {
            var client = factory.CreateClient();

            var requestBody = new PublishAddGateAccessEventCommand
            {
                Gate = "Gate A",
                Timestamp = DateTime.Parse("2023-04-01T08:00:00Z"),
                NumberOfPeople = 100,
                Type = GateAccessType.Enter
            };
            var postResponse = await client.PostAsJsonAsync("/gates", requestBody);
            postResponse.EnsureSuccessStatusCode();

            requestBody = new PublishAddGateAccessEventCommand
            {
                Gate = "Gate A",
                Timestamp = DateTime.Parse("2023-04-01T09:10:00Z"),
                NumberOfPeople = 150,
                Type = GateAccessType.Enter
            };
            postResponse = await client.PostAsJsonAsync("/gates", requestBody);
            postResponse.EnsureSuccessStatusCode();

            requestBody = new PublishAddGateAccessEventCommand
            {
                Gate = "Gate A",
                Timestamp = DateTime.Parse("2023-04-01T11:20:00Z"),
                NumberOfPeople = 50,
                Type = GateAccessType.Exit
            };
            postResponse = await client.PostAsJsonAsync("/gates", requestBody);
            postResponse.EnsureSuccessStatusCode();

            var getResponse = await client.GetAsync("/gates?type=enter");

            getResponse.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.NotNull(getResponse.Content.Headers.ContentType);
            Assert.Equal("application/json; charset=utf-8", getResponse.Content.Headers.ContentType.ToString());

            var getResponseBody = await getResponse.Content.ReadFromJsonAsync<IEnumerable<SensorResult>>();
            Assert.NotNull(getResponseBody);
            Assert.Single(getResponseBody);
            var gateAccess = getResponseBody.Single();
            Assert.Equal("Gate A", gateAccess.Gate);
            Assert.Equal(250, gateAccess.NumberOfPeople);
            Assert.Equal(GateAccessType.Enter, gateAccess.Type);

            getResponse = await client.GetAsync("/gates?startTime=2023-04-01T08:40:00Z");

            getResponse.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.NotNull(getResponse.Content.Headers.ContentType);
            Assert.Equal("application/json; charset=utf-8", getResponse.Content.Headers.ContentType.ToString());

            getResponseBody = await getResponse.Content.ReadFromJsonAsync<IEnumerable<SensorResult>>();
            Assert.NotNull(getResponseBody);

            var responseBodyArray = getResponseBody.ToArray();
            Assert.Equal(2, responseBodyArray.Length);

            var firstGateAccess = responseBodyArray.First();
            Assert.Equal("Gate A", firstGateAccess.Gate);
            Assert.Equal(150, firstGateAccess.NumberOfPeople);
            Assert.Equal(GateAccessType.Enter, firstGateAccess.Type);

            var secondGateAccess = responseBodyArray[1];
            Assert.Equal("Gate A", secondGateAccess.Gate);
            Assert.Equal(50, secondGateAccess.NumberOfPeople);
            Assert.Equal(GateAccessType.Exit, secondGateAccess.Type);
        }
    }
}
