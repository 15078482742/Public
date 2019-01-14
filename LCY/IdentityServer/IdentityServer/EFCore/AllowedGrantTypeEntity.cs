using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EFCore
{
    public class AllowedGrantTypeEntity
    {
        [Key]
        public string AllowedGrantTypeId { get; set; }

        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public ClientEntity ClientEntity { get; set; }
    }
}
