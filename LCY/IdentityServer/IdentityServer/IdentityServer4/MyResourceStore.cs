using IdentityServer.EFCore;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.IdentityServer4
{
    public class MyResourceStore : IResourceStore
    {
        private IdentityContext identityContext { get; }

        public MyResourceStore(IdentityContext identityContext)
        {
            this.identityContext = identityContext;
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var myApiResources = identityContext.ApiResources.Where(entity => entity.Name == name).FirstOrDefault();
            ApiResource apiResource = new ApiResource(myApiResources.Name, myApiResources.DisplayName);
            return Task.FromResult(apiResource);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var myIdentityResources = identityContext.IdentityResources.ToList();
            List<IdentityResource> identityResources = new List<IdentityResource>();
            foreach (var myIdentityResource in myIdentityResources)
            {
                identityResources.Add(new IdentityResource()
                {
                    Required = myIdentityResource.Required,
                    Emphasize = myIdentityResource.Emphasize,
                    ShowInDiscoveryDocument = myIdentityResource.ShowInDiscoveryDocument
                });
            }
            var myApiResources = identityContext.ApiResources.ToList();
            List<ApiResource> apiResources = new List<ApiResource>();
            foreach (var myApiResource in myApiResources)
            {
                var myScopes = identityContext.Scopes.ToList();
                List<Scope> scopes = new List<Scope>();
                var mySecrets = identityContext.Secrets.ToList();
                List<Secret> secrets = new List<Secret>();
                foreach (var myScope in myScopes)
                {
                    scopes.Add(new Scope()
                    {
                        Name = myScope.Name,
                        DisplayName = myScope.DisplayName,
                        Emphasize = myScope.Emphasize,
                        Description = myScope.Description,
                        Required = myScope.Required,
                        ShowInDiscoveryDocument = myScope.ShowInDiscoveryDocument
                    });
                }
                foreach (var mySecret in mySecrets)
                {
                    secrets.Add(new Secret()
                    {
                        Description = mySecret.Description,
                        Value = mySecret.Value,
                        Expiration = mySecret.Expiration,
                        Type = mySecret.Type
                    });
                }
                apiResources.Add(new ApiResource()
                {
                    Scopes = scopes,
                    ApiSecrets = secrets
                });
            }
            var result = new Resources(identityResources, apiResources);
            return Task.FromResult(result);
        }
    }
}