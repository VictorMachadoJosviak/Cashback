using Cashback.Infra.DTO.Authentication;
using Cashback.Integration.Fixtures;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cashback.Integration.Scenarios
{
    public class LoginTest
    {
        private readonly TestContext _testContext;
        public LoginTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Login_Post_ReturnsOkResponse()
        {
            var credentials = new CredentialsDTO
            {
                Email = "a@a.com",
                Password = "123"
            };

            var json = JsonConvert.SerializeObject(credentials);

            var content = new StringContent(json,Encoding.UTF8,"application/json");

            var response = await _testContext.Client.PostAsync("/api/login",content);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login_Post_ReturnsUnauthorized()
        {
            var credentials = new CredentialsDTO
            {
                Email = "z@z.com",
                Password = "asdasdas"
            };

            var json = JsonConvert.SerializeObject(credentials);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _testContext.Client.PostAsync("/api/login", content);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
