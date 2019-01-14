using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EFCore
{
    public class ClientScopeEntity
    {
        [Key]
        public string ScopeId { get; set; }
        public string ScopeName { get; set; }

        public string ClientId { get; set; }
        public ClientEntity ClientEntity { get; set; }
    }
}
