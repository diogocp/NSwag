using Microsoft.AspNetCore.Mvc.Testing;
using NSwagPlainTextBug.Client;
using System.Threading.Tasks;
using Xunit;

namespace NSwagPlainTextBug.Tests
{
    public class ClientTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly NSwagPlainTextBugClient _client;

        public ClientTests(WebApplicationFactory<Startup> factory)
        {
            _client = new NSwagPlainTextBugClient(null, factory.CreateClient());
        }

        [Fact]
        public async Task GetHello_ReturnsOk()
        {
            var response = await _client.HelloAsync();
        }
    }
}
