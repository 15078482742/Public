using IdentityServer.EFCore;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var myClient = identityContext.Clients.Include(entity => entity.AllowedScopes).Include(entity => entity.ClientSecrets).Include(entity => entity.AllowedGrantTypes).Where(entity => entity.ClientId == clientId).FirstOrDefault();
            ICollection<string> allowedScopes = myClient.AllowedScopes.Select(entity => entity.ScopeName).ToList();
            ICollection<Secret> secrets = new List<Secret>();
            foreach (var secret in myClient.ClientSecrets)
            {
                secrets.Add(new Secret(secret.Value.Sha256()));
            }
            Client id4Client = new Client()
            {
                ClientId = myClient.ClientId,
                AllowedGrantTypes = GetGrantType(myClient.AllowedGrantTypes.GrantType),
                ClientSecrets = secrets.ToHashSet(),
                AllowedScopes = allowedScopes,
                Enabled = myClient.Enabled,
                ClientName = myClient.ClientName
            };
            return Task.FromResult(id4Client);
        }

        public ICollection<string> GetGrantType(string value)
        {
            Type type = typeof(GrantType);
            foreach (var item in type.GetProperties(BindingFlags.Public))
            {
                if (value == item.Name)
                    return (ICollection<string>)type.GetProperty(value).GetValue(null, null);
            }
            throw new Exception("没有符合GrantType的类型");
        }
    }
}