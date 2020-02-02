using Cashback.Infra.DTO.Authentication;
using Cashback.Infra.DTO.Sale;
using Cashback.Integration.Fixtures;
using Cashback.Integration.Test.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cashback.Integration.Test.Scenarios
{
    public class SaleTest
    {
        private readonly TestContext _testContext;

        public SaleTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Sale_Create_Post_OkResponse()
        {
            var createSale = new CreateSaleDTO
            {
                Code = new Random().Next(1, 50000).ToString(),
                CPF = "15350946056",
                Date = DateTime.Now,
                Value = 200
            };

            var json = JsonConvert.SerializeObject(createSale);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var token = await Authenticate();

            _testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            var response = await _testContext.Client.PostAsync("/api/sale", content);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Sale_List_Get_OkResponse()
        {
            var token = await Authenticate();
            _testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            var response = await _testContext.Client.GetAsync("/api/sale");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);           
        }

        [Fact]
        public async Task Sale_ListCashback_Get_OkResponse()
        {
            var cpf = "12312312323";

            var token = await Authenticate();
            _testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            var response = await _testContext.Client.GetAsync("/api/sale/cashback?cpf=" + cpf);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        private async Task<Token> Authenticate()
        {
            var credentials = new CredentialsDTO
            {
                Email = "a@a.com",
                Password = "123"
            };

            var json = JsonConvert.SerializeObject(credentials);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var loginResponse = await _testContext.Client.PostAsync("/api/login", content);

            var respContent = await loginResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Token>(respContent);
        }

    }
}
