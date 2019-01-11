using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EFCore
{
    public class IdentityContext:DbContext
    {
        public IdentityContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ApiResourceEntity> ApiResources { get; set; }
        public DbSet<IdentityResourceEntity> IdentityResources { get; set; }
        public DbSet<ScopeEntity> Scopes { get; set; }
        public DbSet<SecretEntity> Secrets { get; set; }

    }
}
