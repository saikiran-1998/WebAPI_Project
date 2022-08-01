using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPI_Project.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var discoverDocument = await client.GetDiscoveryDocumentAsync("http://localhost:63176");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoverDocument.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "Demoapi",
                    Scope = "project-api"
                }
                );

            Console.WriteLine("Token : "+ tokenResponse.AccessToken);
        }
    }
}
