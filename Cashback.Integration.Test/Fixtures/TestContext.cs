using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Cashback.API;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Configuration;

namespace Cashback.Integration.Fixtures
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;
        public TestContext()
        {
            SetupClient();
        }
        private void SetupClient()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            var webHost = new WebHostBuilder().UseStartup<Startup>();

            webHost.ConfigureAppConfiguration((context, conf) =>
            {
                conf.AddJsonFile(configPath);
            });
       
            _server = new TestServer(webHost);
            Client = _server.CreateClient();
        }
    }
}
