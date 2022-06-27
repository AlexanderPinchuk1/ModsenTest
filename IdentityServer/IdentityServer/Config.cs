using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    AllowedGrantTypes =  GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { "https://localhost:8888" },
                    AllowedScopes = { "AdminMeetupAPI" }
                }
            };


        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("AdminMeetupAPI", "Admin Meetup API");
        }
    }
}
