using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using StocksBot;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject
{
    public class StocksBotUnitTest
    {
        [Fact]
        public async Task StockBot_GetStock_Success()
        {
            TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            using var client = server.CreateClient();
            string stockCode = "wig20";
            HttpResponseMessage resp = await client.GetAsync($"StocksBot/GetStock?stockCode={stockCode}");
            resp.EnsureSuccessStatusCode();
            Assert.NotNull(resp);
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact]
        public async Task StockBot_GetStock_Failed()
        {
            TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            using var client = server.CreateClient();
            string stockCode = string.Empty;
            HttpResponseMessage resp = await client.GetAsync($"StocksBot/GetStock?stockCode={stockCode}");
            bool status = !resp.IsSuccessStatusCode;
            Assert.True(status);
        }
    }
}
