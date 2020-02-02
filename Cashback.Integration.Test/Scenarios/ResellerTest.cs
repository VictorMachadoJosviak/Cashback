using Cashback.Infra.DTO.Reseller;
using Cashback.Integration.Fixtures;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cashback.Integration.Test.Scenarios
{
    public class ResellerTest
    {
        private readonly TestContext _testContext;

        public ResellerTest()
        {
            _testContext = new TestContext();

        }

        [Fact]
        public async Task Reseller_Create_Post_OkResponse()
        {
            var createReseller = new CreateResellerDTO
            {
                CPF = "60796949050",
                Email = "a@example.com",
                LastName = "Silva",
                Name = "José",
                Password = "123"                
            };

            var json = JsonConvert.SerializeObject(createReseller);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _testContext.Client.PostAsync("/api/reseller", content);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Reseller_Create_Post_BadRequest()
        {
            var createReseller = new CreateResellerDTO
            {
                CPF = "123",
                Email = "email@example.com",
                LastName = "Silva",
                Name = "José",
                Password = "123"
            };

            var json = JsonConvert.SerializeObject(createReseller);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _testContext.Client.PostAsync("/api/reseller", content);

            response.StatusCode.Should().Be (HttpStatusCode.BadRequest);
        }

    }
}
