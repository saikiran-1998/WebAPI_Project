using IdentityServer4.Models;
using System.Collections.Generic;

namespace WebAPIProject_IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> Apis
        {
            get
            {
                return new List<ApiResource>
                {
                new ApiResource("project-api", "Demo API")
                };
            }
        }
        public static IEnumerable<Client> Clients
        {
            get
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = "client",
                        AllowedScopes = { "project-api" },

                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("Demoapi".Sha256())
                        }
                    }
                };
            }
        }
        public static IEnumerable<ApiScope> Scopes
        {
            get
            {
                return new List<ApiScope>
                {
                    new ApiScope("project-api")
                };
            }
        }
    }
}
