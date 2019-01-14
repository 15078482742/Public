using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdentityModel;
using System.Security.Claims;
using System.Linq;
using System;
using System.Collections;
using System.Diagnostics;
using IdentityServer4.Models;

namespace IdentityServer.EFCore
{
    public class ClientEntity
    {
        [Key]
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public ICollection<ClientSecretEntity> ClientSecrets { get; set; }
        public AllowedGrantTypeEntity AllowedGrantTypes { get; set; }
        public ICollection<ClientScopeEntity> AllowedScopes { get; set; }
        public bool Enabled { get; set; }
    }
}