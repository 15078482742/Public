using IdentityServer.EFCore;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.IdentityServer4
{
    public class MyClientStore : IClientStore
    {
        private IdentityContext identityContext { get; }

        public MyClientStore(IdentityContext identityContext)
        {
            this.identityContext = identityContext;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var myClient = identityContext.Clients.Where(entity => entity.ClientId == clientId).FirstOrDefault();
            Client id4Client = new Client()
            {
                ClientId = myClient.ClientId,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret(myClient.AllowedScopes.Sha256())
                },
                AllowedScopes = { myClient.AllowedScopes }
            };
            return Task.FromResult(id4Client);
        }
    }
}