//using Microsoft.Extensions.Logging;
//using DominiosRicos.Api.Controllers.Auth;

namespace DominiosRicos.Teste
{
    public class Request
    {
        /*     private readonly TestServer _server;
             private readonly HttpClient _client;
             private HttpParams httpParams = new HttpParams();
             public Request()
             {
                 // Arrange

                 _server = new TestServer(new WebHostBuilder()
                         .UseEnvironment("Development")
                         .UseUrls("http://*:5100")
                         .UseStartup<Startup>());

                 _client = _server.CreateClient();
             }
             public async Task<T> GetBaseAsync<T>(string resource)
             {
                 //httpParams.Add("access_token", _client.Credentials.AccessToken);
                 //httpParams.Add("refresh_token", _client.Credentials.RefreshToken);

                 var response = await _client.GetAsync(resource);
                 if (!response.IsSuccessStatusCode) throw new NotImplementedException();
                 var teste = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                 return teste;
             }

             [Fact]
             public async Task LoginAsync()
             {
                 //var t = Task.Run(async () =>
                 //{
                     var response = await _client.GetAsync("/Auth/login", HttpCompletionOption);
                     response.EnsureSuccessStatusCode();
                     var responseString = await response.Content.ReadAsStringAsync();
                     Assert.Equal("Hello World!", responseString);

                 //});
                 //t.Wait();
                 // Assert
             }*/
    }
}