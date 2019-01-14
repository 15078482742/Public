using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EFCore
{
    public class ClientSecretEntity
    {
        [Key]
        public string ClientSecretId { get; set; }
        public string Value { get; set; }

        public string ClientId { get; set; }
        public ClientEntity ClientEntity { get; set; }
    }
}
