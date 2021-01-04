using DominiosRicos.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DominiosRicos.Teste.Integracao
{
    public class Publico
    {
        public readonly HttpClient _client;

        public Publico()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .UseUrls("http://*:5100"));
            server.Host.Run();
            _client = server.CreateClient();
        }

        [Fact]
        public void ValidaServidor()
        {
            Assert.Equal("http://localhost/", _client.BaseAddress.ToString());
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetDropDownAsync(string Method)
        {
            var request = new HttpRequestMessage(new HttpMethod(Method), "dropdown/grupos");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //[Fact]
        //public async System.Threading.Tasks.Task GetDropDownAsync()
        //{
        //    var dropDown = await _client.GetAsync($"{_client.BaseAddress}Dropdown/grupos");

        //    //var response = await meli.GetAsync("/users/me", p);
        //    Assert.Equal(HttpStatusCode.OK, dropDown.StatusCode);
        //    if (dropDown.IsSuccessStatusCode)
        //    {
        //        var json = await dropDown.Content.ReadAsStringAsync();
        //        Assert.IsType<Grupo>(JsonConvert.DeserializeObject<Grupo>(json));
        //    }
        //    else
        //    {
        //        throw new ArgumentException("A Resposta falhou");
        //    }
        //}
    }
}